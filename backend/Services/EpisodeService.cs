using System.Net.Http;
using System.Text.Json;
using BackPruebaTecnicaCarsales.DTOs;
using BackPruebaTecnicaCarsales.Interfaces;
using BackPruebaTecnicaCarsales.Models;

namespace BackPruebaTecnicaCarsales.Services
{
    public class EpisodeService(HttpClient httpClient, IConfiguration configuration, ICharacterService characterService) : IEpisodeService
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<PagedResponse<EpisodeDto>> GetEpisodesAsync(int page)
        {
            try
            {
                var baseUrl = configuration["RickAndMortyApi:BaseUrl"];
                var response = await httpClient.GetAsync($"{baseUrl}/episode?page={page}");

                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException($"Error al obtener episodios. Código de estado: {(int)response.StatusCode}");

                var content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<ApiResponse<EpisodeDto>>(content, _jsonOptions);

                var episodes = data?.Results.Select(episode => new EpisodeDto
                {
                    Id = episode.Id,
                    Name = episode.Name,
                    AirDate = episode.AirDate,
                    Episode = episode.Episode,
                    Characters = episode.Characters ?? new List<string>(),
                    Created = episode.Created
                }).ToList() ?? new List<EpisodeDto>();

                foreach (var episode in episodes)
                {
                    episode.CharactersDetails = await characterService.GetCharactersAsync(episode.Characters!);
                }

                return new PagedResponse<EpisodeDto>
                {
                    CurrentPage = page,
                    TotalPages = data?.Info?.Pages ?? 0,
                    TotalItems = data?.Info?.Count ?? 0,
                    Items = episodes
                };
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error inesperado al obtener los episodios.", ex);
            }
        }
    }
}
