using System.ComponentModel.DataAnnotations;

namespace Project_PL.Models
{
    public class SignUpViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
        [Required]
        [MaxLength(15)]
        [Compare(nameof(Password),ErrorMessage = "Password Mismatch")]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool IsAgree { get; set; }
    }
}
