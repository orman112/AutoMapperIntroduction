using AutoMapper.Configuration.Conventions;

namespace AutoMapperIntroduction.Entities
{
    public class CoachEntity
    {
        public int CoachId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? YearsCoaching { get; set; }
        [MapTo("AlmaMater")]
        public string Schooling { get; set; }
        public CoachStatus Status { get; set; }

        public enum CoachStatus
        {
            Retired,
            Active,
            Suspended
        }
    }
}
