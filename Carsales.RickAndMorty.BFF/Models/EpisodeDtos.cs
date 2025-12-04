namespace Carsales.RickAndMorty.BFF.Models
{
    public sealed class RickAndMortyEpisodeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AirDate { get; set; } = string.Empty;
        public string EpisodeCode { get; set; } = string.Empty;
    }

    public sealed class EpisodePageDto
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public IReadOnlyCollection<RickAndMortyEpisodeDto> Items { get; set; } = Array.Empty<RickAndMortyEpisodeDto>();
    }
}