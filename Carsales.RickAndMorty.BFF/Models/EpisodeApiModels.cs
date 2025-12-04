namespace Carsales.RickAndMorty.BFF.Models
{
    public sealed class EpisodeInfoApiModel
    {
        public int Count { get; set; }
        public int Pages { get; set; }
    }

    public sealed class EpisodeApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Air_Date { get; set; } = string.Empty;
        public string Episode { get; set; } = string.Empty;
    }

    public sealed class EpisodeApiResponse
    {
        public EpisodeInfoApiModel Info { get; set; } = new();
        public List<EpisodeApiModel> Results { get; set; } = new();
    }
}