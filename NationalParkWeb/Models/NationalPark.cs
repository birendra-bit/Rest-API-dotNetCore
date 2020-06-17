using System;
using System.ComponentModel.DataAnnotations;

namespace NationalParkWeb.Models
{
    public class NationalPark
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public DateTime Cerated { get; set; }
        public DateTime Established { get; set; }
        public byte[] Picture { get; set; }
    }
}
