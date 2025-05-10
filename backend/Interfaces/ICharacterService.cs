using BackPruebaTecnicaCarsales.DTOs;

namespace BackPruebaTecnicaCarsales.Interfaces
{
    public interface ICharacterService
    {
        Task<List<CharacterDto>> GetCharactersAsync(List<string> characterUrls);
    }
}
