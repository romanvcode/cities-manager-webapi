using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CitiesManager.Core.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string PersonName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage="Email is already in use.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number should contain only digits.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
