using Carsales.RickAndMorty.BFF.Services;
using Microsoft.AspNetCore.Mvc;

namespace Carsales.RickAndMorty.BFF.Endpoints
{
    /// <summary>
    /// Endpoints relacionados con episodios de Rick and Morty.
    /// </summary>
    public static class EpisodeEndpoints
    {
        public static IEndpointRouteBuilder MapEpisodeEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/episodes")
                .WithTags("Episodios");

            group.MapGet(string.Empty, async (
                [FromQuery] int page,
                IEpisodeService episodeService,
                CancellationToken cancellationToken) =>
            {
                try
                {
                    var result = await episodeService.GetEpisodesAsync(page, cancellationToken);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);

                    return Results.Problem(
                        title: "Error al obtener episodios",
                        detail: "Ocurrió un error inesperado al consultar el servicio externo.",
                        statusCode: StatusCodes.Status502BadGateway);
                }
            })
            .WithSummary("Obtiene una página de episodios")
            .WithDescription("Ejemplo: GET /api/episodes?page=1");

            return app;
        }
    }
}