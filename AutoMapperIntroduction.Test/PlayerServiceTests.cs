using AutoMapper;
using AutoMapperIntroduction.AutoMapper;
using AutoMapperIntroduction.Entities;
using AutoMapperIntroduction.Models;
using AutoMapperIntroduction.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Moq;
using Newtonsoft.Json;

namespace AutoMapperIntroduction.Test
{
    [TestClass]
    public class PlayerServiceTests
    {
        protected PlayerService playerService;
        protected ILogger logger;
        protected Mapper mapper;
        public PlayerServiceTests()
        {
            var logger = new Mock<ILogger>();
            var mapper = new Mapper(new MapperConfiguration(config => config.AddProfile<MappingProfile>()));
            playerService = new PlayerService(mapper, logger.Object);
        }

        [TestMethod]
        public void ModelMapShouldReturnModelObject()
        {
            //create entity
            var entity = playerService.GetPlayerEntity();

            //map to model
            var mappedModel = playerService.MapFromEntityToModel();
            var generatedModel = playerService.GetPlayerModel();

            Assert.IsTrue(mappedModel is PlayerModel);            
            Assert.AreEqual(JsonConvert.SerializeObject(generatedModel), JsonConvert.SerializeObject(mappedModel));
        }

        [TestMethod]
        public void EntityMapShouldReturnEntityObject()
        {
            //create model
            var model = playerService.GetPlayerModel();

            //map to entity
            var mappedEntity = playerService.MapFromModelToEntity();
            var generatedEntity = playerService.GetPlayerEntity();

            Assert.IsTrue(mappedEntity is PlayerEntity);
            Assert.AreEqual(JsonConvert.SerializeObject(generatedEntity), JsonConvert.SerializeObject(mappedEntity));
        }
    }
}
