using System.Text.Json.Serialization;

namespace BackPruebaTecnicaCarsales.DTOs
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [JsonPropertyName("air_date")]
        public required string AirDate { get; set; }
        [JsonPropertyName("episode")]
        public required string Episode { get; set; }
        public required string Created { get; set; }
        public List<CharacterDto>? CharactersDetails { get; set; }
        public List<string>? Characters { get; set; }
    }
}
