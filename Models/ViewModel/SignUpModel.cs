using System.ComponentModel.DataAnnotations;

namespace LMS.Models.ViewModel
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be a 10-digit numeric value.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(8, ErrorMessage = "Password must be 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Required(ErrorMessage = "Confirm Password is required.")]
        public string ConfirmPassword { get; set; }

        public bool IsActive { get; set; }

        //public int Id { get; set; }
        //[Required(ErrorMessage = "Username cannot be Blank")]
        //public string? Username { get; set; }
        //[Required(ErrorMessage = "Email is Required")]
        //public string? Email { get; set; }

        //public long Mobile { get; set; }
        //[Required(ErrorMessage = "Password cannot be Blank")]
        //public string? Password { get; set; }
        //[Compare("Password")]
        //[Required(ErrorMessage = "Confirm password not Matched")]
        //public string? ConfirmPassword { get; set; }
        //[Required(ErrorMessage = "Checkbox need to selet")]
        //public bool IsActive { get; set; }

        //[Display(Name = "Remember me")]
        //public bool IsRemember { get; set; }
    }
}

