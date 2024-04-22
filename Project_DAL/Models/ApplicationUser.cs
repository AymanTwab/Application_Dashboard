using Microsoft.AspNetCore.Identity;

namespace Project_DAL.Models
{
    public class ApplicationUser:IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
