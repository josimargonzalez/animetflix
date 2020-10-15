using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animetflix.Models.Entities;
using animetflix.Models.DTOs;

namespace animetflix.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Genero,GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO,Genero>();

            CreateMap<Personaje,PersonajeDTO>().ReverseMap();
            CreateMap<PersonajeCreacionDTO,Personaje>();
        }
    }
}
