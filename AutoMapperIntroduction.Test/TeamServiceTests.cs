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
    public class TeamServiceTests
    {
        protected TeamService teamService;
        protected ILogger logger;
        protected Mapper mapper;

        public TeamServiceTests()
        {
            var logger = new Mock<ILogger>();
            var mapper = new Mapper(new MapperConfiguration(config => config.AddProfile<MappingProfile>()));
            teamService = new TeamService(mapper, logger.Object);
        }
        
        [TestMethod]
        public void ModelMapShouldReturnModelObject()
        {
            //create entity
            var entity = teamService.GetTeamEntity();

            //map to model
            var mappedModel = teamService.MapFromEntityToModel();

            Assert.IsTrue(mappedModel is TeamModel);
        }

        [TestMethod]
        public void ModelMapShouldReturnCorrectCountOfPlayers()
        {
            //create entity
            var entity = teamService.GetTeamEntity();

            //map to model
            var mappedModel = teamService.MapFromEntityToModel();

            Assert.AreEqual(3, mappedModel.Players.Count);
        }
    }
}
