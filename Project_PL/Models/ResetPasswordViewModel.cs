using System.ComponentModel.DataAnnotations;

namespace Project_PL.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }
        [Required]
        [MinLength(6)]
        [Compare(nameof(NewPassword),ErrorMessage ="Password MisMatch")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
