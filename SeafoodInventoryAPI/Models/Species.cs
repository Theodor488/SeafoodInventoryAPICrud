using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeafoodInventoryAPI.Models
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConservationStatus { get; set; }
    }
}
