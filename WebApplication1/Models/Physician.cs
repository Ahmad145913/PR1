using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Physician
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhysicianId { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Specialty { get; set; }

        public string Address { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
