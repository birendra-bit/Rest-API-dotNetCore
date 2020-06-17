using System.ComponentModel.DataAnnotations;

namespace NationalParkWeb.Models
{
    public class Trial
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Distance { get; set; }

        public enum DiffcultyType { Easy, Moderate, Diffcult, Expert }

        public DiffcultyType Diffculty { get; set; }

        [Required]
        public int NationalParkId { get; set; }
        public NationalPark NationalPark { get; set; }
    }
}
