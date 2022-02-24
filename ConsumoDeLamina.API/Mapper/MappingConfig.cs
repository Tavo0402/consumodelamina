using AutoMapper;
using ConsumoDeLamina.Entities.DTOs;
using ConsumoDeLamina.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoDeLamina.API.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ConsumoDeLamin, ConsumoDeLaminDTO>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
