using BackPruebaTecnicaCarsales.DTOs;
using BackPruebaTecnicaCarsales.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace BackPruebaTecnicaCarsales.Services
{
    public class CharacterService(HttpClient httpClient) : ICharacterService
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };


        public async Task<List<CharacterDto>> GetCharactersAsync(List<string> characterUrls)
        {
            var characterIds = characterUrls
                .Select(url => url.Split('/').Last())
                .ToList();

            var ids = string.Join(",", characterIds);
            var response = await httpClient.GetAsync($"https://rickandmortyapi.com/api/character/{ids}");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error al obtener personajes. Código de estado: {(int)response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();

            var root = JsonSerializer.Deserialize<JsonElement>(content, _jsonOptions);

            if (root.ValueKind == JsonValueKind.Object)
            {
                var character = JsonSerializer.Deserialize<CharacterDto>(root.GetRawText(), _jsonOptions);
                return new List<CharacterDto> { character! };
            }
            else if (root.ValueKind == JsonValueKind.Array)
            {
                return JsonSerializer.Deserialize<List<CharacterDto>>(root.GetRawText(), _jsonOptions)!;
            }

            throw new ApplicationException("Formato JSON inesperado al obtener personajes.");
        }
    }
}
