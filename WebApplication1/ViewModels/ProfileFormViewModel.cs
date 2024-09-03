using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class ProfileFormViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string phoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
