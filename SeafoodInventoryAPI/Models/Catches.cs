using System.ComponentModel.DataAnnotations;

namespace SeafoodInventoryAPI.Models
{
    public class Catches
    {
        [Key]
        public int CatchId { get; set; }
        [Required]
        public int SpeciesId { get; }
        public int VesselId { get; set; }
        public float Weight { get; set; }
        public DateTime CatchDate { get; set; }
        public string Location { get; set; }
        public string Method { get; set; }
        public float BycatchWeight { get; set; }
        public bool IsSustainable { get; set; }
        public string Remarks { get; set; }
    }
}
