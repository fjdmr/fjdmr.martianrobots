using AutoMapper;
using fjdmr.martianrobots.dl.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fjdmr.martianrobots.api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RobotParameters, RobotParametersDto>();


        }
    }
}
