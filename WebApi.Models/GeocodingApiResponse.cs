namespace WebApi.Models
{
    public class GeocodingApiResponse
    {
        public IEnumerable<Location> Results { get; set; } = Enumerable.Empty<Location>();
    }

}