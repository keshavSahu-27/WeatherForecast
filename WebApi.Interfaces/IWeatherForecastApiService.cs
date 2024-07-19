using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IWeatherForecastApiService
    {
        public Task<Response<IEnumerable<Location>?>> GetLocationsAsync(string searchTerm);

        public Task<Response<WeatherForecast?>> GetWeatherForecastAsync(double lat, double lon, int days);
    }
}