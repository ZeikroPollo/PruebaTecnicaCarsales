using Carsales.RickAndMorty.BFF.Models;

namespace Carsales.RickAndMorty.BFF.Clients
{
    /// <summary>
    /// Define el contrato para consumir la API de Rick and Morty.
    /// </summary>
    public interface IRickAndMortyApiClient
    {
        /// <summary>
        /// Obtiene los episodios de la API externa según la página indicada.
        /// </summary>
        Task<EpisodeApiResponse?> GetEpisodesAsync(int page, CancellationToken cancellationToken = default);
    }
}