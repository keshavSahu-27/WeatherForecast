using Newtonsoft.Json;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.ApiServices
{
    public class WeatherForecastApiService : IWeatherForecastApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Response<IEnumerable<Location>?>> GetLocationsAsync(string searchTerm)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                var response = await httpClient
                    .GetAsync($"https://geocoding-api.open-meteo.com/v1/search?name={searchTerm}");


                GeocodingApiResponse? location = null;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    location = JsonConvert.DeserializeObject<GeocodingApiResponse>(result);

                    if (location == null)
                    {
                        throw new ArgumentNullException("Some issue occured while deserializing the data");
                    }

                }

                return new Response<IEnumerable<Location>?>
                {
                    Result = location?.Results.ToList(),
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase ?? "NO_REASON_PROVIDED"
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Location>?>
                {
                    Result = null,
                    StatusCode = 500,
                    Message = "INTERNAL_SERVER_ERROR"
                };
            }
        }

        public async Task<Response<WeatherForecast?>> GetWeatherForecastAsync(double lat, double lon, int days)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                var response = await httpClient
                    .GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&forecast_days={days}&hourly=relative_humidity_2m&daily=temperature_2m_max,temperature_2m_min,apparent_temperature_max,apparent_temperature_min,precipitation_sum,precipitation_probability_max");

                ForecastApiResponse? forecastedData = null;

                WeatherForecast? resultantObj = null;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    forecastedData = JsonConvert.DeserializeObject<ForecastApiResponse>(result);

                    if (forecastedData == null)
                    {
                        throw new ArgumentNullException("Some issue occured while deserializing the data");
                    }

                    var humidity = forecastedData.Hourly.Time.Select((dt, index) =>
                        {
                            DateTime date = DateTime.Parse(dt).Date;
                            return new { Date = date, Humidity = forecastedData.Hourly.RelativeHumidity2m[index] };
                        })
                        .GroupBy(x => x.Date)
                        .Select(d => new
                        {
                            Date = d.Key,
                            AverageRelativeHumidity2m = d.Average(e => e.Humidity)
                        })
                        .OrderBy(x => x.Date)
                        .Select(e => e.AverageRelativeHumidity2m)
                        .ToList();

                    forecastedData.Daily.AverageRelativeHumidity2m = humidity.ToArray();
                    forecastedData.DailyUnits.AverageRelativeHumidity2m = forecastedData.HourlyUnits.RelativeHumidity2m;
                }

                return new Response<WeatherForecast?>
                {
                    Result = forecastedData != null ? (WeatherForecast)forecastedData : null,
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase ?? "NO_REASON_PROVIDED"
                };
            }
            catch (Exception ex)
            {
                return new Response<WeatherForecast?>
                {
                    Result = null,
                    StatusCode = 500,
                    Message = "INTERNAL_SERVER_ERROR"
                };
            }
        }

    }
}