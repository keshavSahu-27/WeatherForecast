using Newtonsoft.Json;

namespace WebApi.Models
{
  public class WeatherForecast
  {
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double GenerationTimeMs { get; set; }
    public int UtcOffsetSeconds { get; set; }

    public string Timezone { get; set; } = string.Empty;
    public string TimezoneAbbreviation { get; set; } = string.Empty;

    public double Elevation { get; set; }
    public DailyUnits DailyUnits { get; set; }

    public DailyData Daily { get; set; }

    public static explicit operator WeatherForecast(ForecastApiResponse v)
    {
      WeatherForecast weatherForecast = new WeatherForecast
      {
        Latitude = v.Latitude,
        Longitude = v.Longitude,
        GenerationTimeMs = v.GenerationTimeMs,
        UtcOffsetSeconds = v.UtcOffsetSeconds,
        Timezone = v.Timezone,
        TimezoneAbbreviation = v.TimezoneAbbreviation,
        Elevation = v.Elevation,
        DailyUnits = v.DailyUnits,
        Daily = v.Daily
      };
      return weatherForecast;
    }
  }
}