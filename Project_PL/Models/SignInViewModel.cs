using System.ComponentModel.DataAnnotations;

namespace Project_PL.Models
{
    public class SignInViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public bool RemmeberMe { get; set; }
    }
}
