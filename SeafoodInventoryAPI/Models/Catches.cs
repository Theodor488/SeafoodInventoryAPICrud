using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeafoodInventoryAPI.Models
{
    public class Catches
    {
        [Key]
        public int CatchId { get; set; }
        public int SpeciesId { get; private set; }

        [ForeignKey("SpeciesId")]
        public Species Species { get; set; } // Navigation property

        public int VesselId { get; set; }
        public decimal Weight { get; set; }
        public DateTime CatchDate { get; set; }
        public string Location { get; set; }
        public string Method { get; set; }
        public decimal BycatchWeight { get; set; }
        public bool IsSustainable { get; set; }
        public string Remarks { get; set; }
    }
}
