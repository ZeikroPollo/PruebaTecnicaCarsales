using Carsales.RickAndMorty.BFF.Models;

namespace Carsales.RickAndMorty.BFF.Services
{
    /// <summary>
    /// Define la lógica de negocio para trabajar con episodios.
    /// </summary>
    public interface IEpisodeService
    {
        /// <summary>
        /// Obtiene una página de episodios de Rick and Morty lista para el frontend.
        /// </summary>
        Task<EpisodePageDto> GetEpisodesAsync(int page, CancellationToken cancellationToken = default);
    }
}