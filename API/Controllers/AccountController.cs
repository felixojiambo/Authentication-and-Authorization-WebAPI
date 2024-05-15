using API.Dtos;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //api/account
    public class AccountController:ControllerBase
    {
       private readonly UserManager<AppUser> _userManager;
       private readonly RoleManager<IdentityRole>_roleManager;
       private readonly IConfiguration _configuration;
       public AccountController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,IConfiguration configuration)
       {
        _userManager=userManager;
        _roleManager=roleManager;
        _configuration=configuration;
       }

       //api/account/register
       [HttpPost("register")]
       public async Task<ActionResult<string>> Register(RegisterDto registerDto){
        if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }
        var user=new AppUser{
        Email=registerDto.Email,
        FullName=registerDto.FullName,
        UserName=registerDto.Email
        };
        var result=await _userManager.CreateAsync(user,registerDto.Password);
         if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            
            if(registerDto.Roles is null){
                    await _userManager.AddToRoleAsync(user,"User");
            }else{
                foreach(var role in registerDto.Roles)
                {
                    await _userManager.AddToRoleAsync(user,role);
       }
    }
     return Ok(new AuthResponseDto{
            IsSuccess = true,
            Message = "Account Created Sucessfully!"
        });
}
 //api/account/login
        [AllowAnonymous]
        [HttpPost("login")]

        public async Task<ActionResult<AuthResponseDto>> Login(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
            {
               return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if(user is null)
            {
                return Unauthorized(new AuthResponseDto{
                    IsSuccess = false,
                    Message = "User not found with this email",
                });
            }

            var result = await _userManager.CheckPasswordAsync(user,loginDto.Password);

            if(!result){
                return Unauthorized(new AuthResponseDto{
                    IsSuccess=false,
                    Message= "Invalid Password."
                });
            }

            
            var token = GenerateToken(user);

            return Ok(new AuthResponseDto{
                Token = token,
                IsSuccess = true,
                Message = "Login Success."
            });


        }
