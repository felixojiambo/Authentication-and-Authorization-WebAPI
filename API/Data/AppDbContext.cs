using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options)
    {
    }
}
//without primary consttructor we use 
//  public class AppDbContext:IdentityDbContext<AppUser>
//     {
//         public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
//         {
            
//         }    
//     }