using AutoMapper;
using AutoMapperIntroduction.Entities;
using AutoMapperIntroduction.Models;
using System;

namespace AutoMapperIntroduction.AutoMapper.Resolver
{
    public class PlayerModelHeightResolver : IValueResolver<PlayerEntity, PlayerModel, string>
    {
        public string Resolve(PlayerEntity source, PlayerModel destination, string destMember, ResolutionContext context)
        {
            var feet = source.HeightInInches / 12;
            var inches = source.HeightInInches % 12;
            return $"{feet}'{inches}\"";
        }
    }
}