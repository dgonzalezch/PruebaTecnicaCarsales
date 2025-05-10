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
        public required List<string> Characters { get; set; }
        public required string Created { get; set; }
    }
}
