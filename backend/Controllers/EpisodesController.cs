using BackPruebaTecnicaCarsales.DTOs;
using BackPruebaTecnicaCarsales.Interfaces;
using BackPruebaTecnicaCarsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackPruebaTecnicaCarsales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodesController(IEpisodeService episodeService) : ControllerBase
    {
        private readonly IEpisodeService _episodeService = episodeService;

        [HttpGet]
        public async Task<ActionResult<PagedResponse<EpisodeDto>>> GetEpisodes([FromQuery] int page = 1)
        {
            var result = await _episodeService.GetEpisodesAsync(page);
            return Ok(result);
        }
    }
}
