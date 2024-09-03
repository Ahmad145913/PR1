using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MedicalFacility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [ForeignKey("Location")]
        public string LocationId { get; set; }
        public Location Location { get; set; }

        [ForeignKey("Manager")]
        public string ManagerId { get; set; }
        public ApplicationUser Manager { get; set; }

        [ForeignKey("FacilityType")]
        public string FacilityTypeId { get; set; }
        public FacilityType FacilityType { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(20)]
        public string EmergencyNumber { get; set; }

        [MaxLength(50)]
        public string FaxNumber { get; set; }

        [Required]
        [MaxLength(15)]
        public string CountryCode { get; set; }

        [MaxLength(450)]
        public string PictureUrl { get; set; }

        [Timestamp]
        public DateTime CreatedAt { get; set; }
    }
}
