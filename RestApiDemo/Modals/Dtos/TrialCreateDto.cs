using System.ComponentModel.DataAnnotations;
using static RestApiDemo.Modals.Trial;

namespace RestApiDemo.Modals.Dtos
{
    public class TrialCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Distance { get; set; }

        public DiffcultyType Diffculty { get; set; }

        [Required]
        public int NationalParkId { get; set; }
    }
}
