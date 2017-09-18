using AutoMapper;
using AutoMapperIntroduction.Entities;
using AutoMapperIntroduction.Models;
using AutoMapperIntroduction.Services.Interface;
using Microsoft.Extensions.Logging;
using static AutoMapperIntroduction.Entities.CoachEntity;

namespace AutoMapperIntroduction.Services
{
    public class CoachService : ICoachService
    {
        private IMapper _mapper;
        private ILogger _logger;

        public CoachService(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public CoachEntity GetCoachEntity()
        {
            return new CoachEntity
            {
                CoachId = 1,
                FirstName = "Kirby",
                LastName = "Smart",
                YearsCoaching = null,
                Schooling = "UGA",
                Status = CoachStatus.Active
            };
        }

        public CoachModel MapFromEntityToModel()
        {
            var entity = GetCoachEntity();

            var model = _mapper.Map<CoachEntity, CoachModel>(entity);

            _logger.LogDebug("Coach Model Created: ", model);
            return model;
        }
    }
}
