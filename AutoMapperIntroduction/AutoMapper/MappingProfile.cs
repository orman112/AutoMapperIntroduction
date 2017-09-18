using AutoMapper;
using AutoMapperIntroduction.AutoMapper.Resolver;
using AutoMapperIntroduction.Entities;
using AutoMapperIntroduction.Models;
using System;

namespace AutoMapperIntroduction.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PlayerEntity, PlayerModel>()
                .ForMember(dest => dest.Height, opt => opt.ResolveUsing<PlayerModelHeightResolver>())
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(source => $"{source.Weight} lbs"))
                .ForMember(dest => dest.Hometown, opt => opt.MapFrom(source => $"{source.HometownCity}, {source.HometownState}"))
                .ReverseMap()
                .ForPath(source => source.HometownCity, opt => opt.MapFrom(dest => dest.Hometown.Substring(0, dest.Hometown.IndexOf(","))))
                .ForPath(source => source.HometownState, opt => opt.MapFrom(dest => dest.Hometown.Substring(dest.Hometown.IndexOf(",") + 2)))
                .ForPath(source => source.Weight, opt => opt.MapFrom(dest => Int32.Parse(dest.Weight.Remove(dest.Weight.IndexOf(" "), 4))))
                //No custom resolvers with ForPath
                .ForPath(source => source.HeightInInches, opt => opt.Ignore())
                .AfterMap((source, dest) => {
                    var inches = Int32.Parse(source.Height.Substring(source.Height.IndexOf("'") + 1, 2));
                    var feet = Int32.Parse(source.Height.Substring(0, source.Height.IndexOf("'")));
                    dest.HeightInInches = (feet * 12) + inches; 
                });
        }
    }
}
