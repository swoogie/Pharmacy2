using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy2.Models
{
    public class User
    {
        public string? Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        [Display(Name = "Username")]
        public string? UserName { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum length is 4")]

        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
        public string? Password { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string? Name { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string? LastName { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string? Address { get; set; }

    }
}