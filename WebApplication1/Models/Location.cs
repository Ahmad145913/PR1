using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [MaxLength(450)]
        public string LocationName { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        public float? Longitude { get; set; }

        public float? Latitude { get; set; }
    }
}
