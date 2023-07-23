

using System.ComponentModel.DataAnnotations;

namespace LMS.Models.ViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(8, ErrorMessage = "Password must be 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool IsActive { get; set; }
    }
}
