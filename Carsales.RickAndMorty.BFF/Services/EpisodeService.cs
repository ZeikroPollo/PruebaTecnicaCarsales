using Carsales.RickAndMorty.BFF.Clients;
using Carsales.RickAndMorty.BFF.Models;

namespace Carsales.RickAndMorty.BFF.Services
{
    /// <summary>
    /// Implementación de la lógica de negocio asociada a los episodios.
    /// </summary>
    public class EpisodeService : IEpisodeService
    {
        private readonly IRickAndMortyApiClient _apiClient;

        public EpisodeService(IRickAndMortyApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<EpisodePageDto> GetEpisodesAsync(int page, CancellationToken cancellationToken = default)
        {
            // no pedir páginas menores a 1.
            if (page < 1)
            {
                page = 1;
            }

            var apiResponse = await _apiClient.GetEpisodesAsync(page, cancellationToken);

            // Si la API externa no responde correctamente, devuelve una página vacía.
            if (apiResponse is null)
            {
                return new EpisodePageDto
                {
                    Page = page,
                    TotalPages = 0,
                    TotalCount = 0,
                    Items = Array.Empty<RickAndMortyEpisodeDto>()
                };
            }

            var episodios = apiResponse.Results
                .Select(e => new RickAndMortyEpisodeDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    AirDate = e.Air_Date,
                    EpisodeCode = e.Episode
                })
                .ToArray();

            return new EpisodePageDto
            {
                Page = page,
                TotalPages = apiResponse.Info.Pages,
                TotalCount = apiResponse.Info.Count,
                Items = episodios
            };
        }
    }
}