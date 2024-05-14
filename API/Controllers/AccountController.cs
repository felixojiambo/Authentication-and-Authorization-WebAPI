using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //api/account
    public class AccountController:ControllerBase
    {
        [HttpGet]
        public string Hi()
        {
            return "hello";
        }
    }
}