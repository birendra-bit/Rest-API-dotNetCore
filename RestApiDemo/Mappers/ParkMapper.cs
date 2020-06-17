using AutoMapper;
using RestApiDemo.Modals;
using RestApiDemo.Modals.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiDemo.Mappers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ParkMapper: Profile
    {
        public ParkMapper()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
            CreateMap<Trial, TrialDto>().ReverseMap();
            CreateMap<Trial, TrialCreateDto>().ReverseMap();
            CreateMap<Trial, TrialUpdateDto>().ReverseMap();
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
