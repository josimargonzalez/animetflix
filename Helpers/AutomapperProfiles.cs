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
            CreateMap<Personaje,PersonajeEdicionDTO>()
                .ForMember(x=>x.Imagen, option => option.MapFrom(dest => dest.Foto))
                .ForMember(x => x.Foto, option => option.Ignore())
                .ReverseMap();

            CreateMap<Serie,SerieDTO>().ReverseMap();
            CreateMap<SerieCreacionDTO,Serie>();
            CreateMap<Serie,SerieEdicionDTO>()
                .ForMember(x=>x.Poster, option => option.MapFrom(dest => dest.PosterUrl))
                .ForMember(x => x.PosterUrl, option => option.Ignore())
                .ReverseMap();
        }
    }
}
