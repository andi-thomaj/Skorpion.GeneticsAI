namespace Skorpion.GeneticsAI.Api.Data.Entities
{
    public class Area : BaseEntity
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }
}
