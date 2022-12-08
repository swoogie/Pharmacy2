using Microsoft.AspNetCore.Identity;

namespace Pharmacy2.Models
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
