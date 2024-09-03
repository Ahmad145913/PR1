using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace WebApplication1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public byte[]? ProfilePicture { get; set; }
        public bool isActive { get; set; }
    }
}
