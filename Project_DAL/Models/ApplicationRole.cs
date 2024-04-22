using Microsoft.AspNetCore.Identity;

namespace Project_DAL.Models
{
    public class ApplicationRole:IdentityRole
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
