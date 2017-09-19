using AutoMapper;
using AutoMapperIntroduction.AutoMapper;
using AutoMapperIntroduction.Models;
using AutoMapperIntroduction.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AutoMapperIntroduction.Test
{
    [TestClass]
    public class CoachServiceTests
    {
        protected CoachService coachService;
        protected ILogger logger;
        protected Mapper mapper;

        public CoachServiceTests()
        {
            var logger = new Mock<ILogger>();
            var mapper = new Mapper(new MapperConfiguration(config => config.AddProfile<MappingProfile>()));
            coachService = new CoachService(mapper, logger.Object);
        }

        [TestMethod]
        public void ModelMapShouldReturnModelObject()
        {
            //create entity
            var entity = coachService.GetCoachEntity();

            //map to model
            var mappedModel = coachService.MapFromEntityToModel();

            Assert.IsTrue(mappedModel is CoachModel);
        }
    }
}
