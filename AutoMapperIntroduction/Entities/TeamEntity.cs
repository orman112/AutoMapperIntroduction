using System.Collections.Generic;

namespace AutoMapperIntroduction.Entities
{
    public class TeamEntity
    {
        public string Mascot { get; set; }
        public ICollection<PlayerEntity> Players { get; set; }
    }
}
