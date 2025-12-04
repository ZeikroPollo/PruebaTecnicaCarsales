using System.Net.Http.Json;
using Carsales.RickAndMorty.BFF.Models;

namespace Carsales.RickAndMorty.BFF.Clients
{
    /// <summary>
    /// Cliente HTTP responsable de comunicarse con la API de Rick and Morty.
    /// </summary>
    public class RickAndMortyApiClient : IRickAndMortyApiClient
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Llama a la API de Rick and Morty para obtener episodios.
        /// </summary>
        public async Task<EpisodeApiResponse?> GetEpisodesAsync(int page, CancellationToken cancellationToken = default)
        {
            // Armamos la ruta con la página solicitada
            var response = await _httpClient.GetAsync($"episode?page={page}", cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                // devuelvo null y dejo que la capa superior decida qué hacer.
                return null;
            }

            // Deserializamos el JSON para la API externa
            return await response.Content.ReadFromJsonAsync<EpisodeApiResponse>(cancellationToken: cancellationToken);
        }
    }
}