using System.ComponentModel.DataAnnotations;

namespace BloggieWeb.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(6 , ErrorMessage = "Passwrod has to be at least 6 characters long")]
        public string Password { get; set; }
        [Required]
        public string ReturnUrl { get; set; }
    }
}
