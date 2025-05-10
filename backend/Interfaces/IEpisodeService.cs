using BackPruebaTecnicaCarsales.DTOs;
using BackPruebaTecnicaCarsales.Models;

namespace BackPruebaTecnicaCarsales.Interfaces
{
    public interface IEpisodeService
    {
        Task<PagedResponse<EpisodeDto>> GetEpisodesAsync(int page);
    }
}
