using System.Collections.Generic;

namespace AutoMapperIntroduction.Models
{
    public class TeamModel
    {
        private readonly string _mascot;
        public TeamModel(string mascot)
        {
            _mascot = mascot;
        }

        public string Mascot => _mascot;
        public List<PlayerModel> Players { get; set; }
    }
}
