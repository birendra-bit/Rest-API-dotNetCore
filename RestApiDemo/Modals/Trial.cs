using RestApiDemo.Modals.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiDemo.Modals
{
    public class Trial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Distance { get; set; }

        public enum DiffcultyType { Easy, Moderate, Diffcult, Expert }

        public DiffcultyType Diffculty { get; set; }

        [Required]
        public int NationalParkId { get; set; }
        [ForeignKey("NationalParkId")]
        public NationalParkDto NationalPark { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
