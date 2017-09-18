using AutoMapper;
using AutoMapperIntroduction.Entities;
using AutoMapperIntroduction.Models;
using AutoMapperIntroduction.Services.Interface;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AutoMapperIntroduction.Services
{
    public class TeamService : ITeamService
    {
        private IMapper _mapper;
        private ILogger _logger;

        public TeamService(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public TeamEntity GetTeamEntity()
        {
            var players = new List<PlayerEntity>
            {
                new PlayerEntity
                {
                    FirstName = "Clayton",
                    LastName = "Orman",
                    Number = 21,
                    HeightInInches = 70,
                    Weight = 175,
                    HometownCity = "Louisville",
                    HometownState = "KY"
                },
                new PlayerEntity
                {
                    FirstName = "John",
                    LastName = "Johnson",
                    Number = 32,
                    HeightInInches = 85,
                    Weight = 300,
                    HometownCity = "Tampa",
                    HometownState = "FL"
                },
                new PlayerEntity
                {
                    FirstName = "Billy",
                    LastName = "Bob",
                    Number = 28,
                    HeightInInches = 72,
                    Weight = 195,
                    HometownCity = "Nashville",
                    HometownState = "TN"
                },
            };

            return new TeamEntity()
            {
                Mascot = "Vikings",
                Players = players
            };
        }

        public TeamModel MapFromEntityToModel()
        {
            var entity = GetTeamEntity();

            var model = _mapper.Map<TeamEntity, TeamModel>(entity);

            _logger.LogDebug("Team Model Created: ", model);
            return model;
        }
    }
}
