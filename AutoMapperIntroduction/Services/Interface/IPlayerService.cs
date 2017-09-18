using AutoMapperIntroduction.Models;

namespace AutoMapperIntroduction.Services.Interface
{
    public interface IPlayerService
    {
        PlayerModel MapFromEntityToModel();
    }
}
