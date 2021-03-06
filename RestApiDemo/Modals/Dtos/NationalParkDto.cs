﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiDemo.Modals.Dtos
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class NationalParkDto
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
