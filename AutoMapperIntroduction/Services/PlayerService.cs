using AutoMapper;
using AutoMapperIntroduction.Entities;
using AutoMapperIntroduction.Models;
using AutoMapperIntroduction.Services.Interface;
using Microsoft.Extensions.Logging;

namespace AutoMapperIntroduction.Services
{
    public class PlayerService : IPlayerService
    {
        private IMapper _mapper;
        private ILogger _logger;

        public PlayerService(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public PlayerEntity GetPlayerEntity()
        {
            return new PlayerEntity
            {
                FirstName = "Clayton",
                LastName = "Orman",
                Number = 21,
                HeightInInches = 70,
                Weight = 175,
                HometownCity = "Louisville",
                HometownState = "KY"
            };
        }

        public PlayerModel GetPlayerModel()
        {
            return new PlayerModel
            {
                FirstName = "Clayton",
                LastName = "Orman",
                Number = 21,
                Height = @"5'10""",
                Weight = "175 lbs",
                Hometown = "Louisville, KY"
            };
        }

        public PlayerModel MapFromEntityToModel()
        {
            var entity = GetPlayerEntity();
            var model = new PlayerModel();

            model = _mapper.Map<PlayerEntity, PlayerModel>(entity);

            _logger.LogDebug("Player Model Created: ", model);
            return model;
        }

        public PlayerEntity MapFromModelToEntity()
        {
            var model = GetPlayerModel();
            var entity = new PlayerEntity();

            entity = _mapper.Map<PlayerModel, PlayerEntity>(model);

            _logger.LogDebug("Player Entity Created: ", entity);
            return entity;
        }
    }
}
