using Newtonsoft.Json;
namespace WebApi.Models
{

    public class HourlyUnits
    {
        public string Time { get; set; }

        [JsonProperty("relative_humidity_2m")]
        public string RelativeHumidity2m { get; set; }
    }

    public class HourlyData
    {
        public string[] Time { get; set; }

        [JsonProperty("relative_humidity_2m")]
        public int[] RelativeHumidity2m { get; set; }
    }

    public class ForecastApiResponse
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [JsonProperty("generationtime_ms")]
        public double GenerationTimeMs { get; set; }

        [JsonProperty("utc_offset_seconds")]
        public int UtcOffsetSeconds { get; set; }

        public string Timezone { get; set; }

        [JsonProperty("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; }

        public double Elevation { get; set; }

        [JsonProperty("daily_units")]
        public DailyUnits DailyUnits { get; set; }

        public DailyData Daily { get; set; }
        [JsonProperty("hourly_units")]
        public HourlyUnits HourlyUnits { get; set; }

        public HourlyData Hourly { get; set; }
    }

    public class DailyUnits
    {
        public string Time { get; set; }

        [JsonProperty("temperature_2m_max")]
        public string Temperature2mMax { get; set; }

        [JsonProperty("temperature_2m_min")]
        public string Temperature2mMin { get; set; }

        [JsonProperty("apparent_temperature_max")]
        public string ApparentTemperatureMax { get; set; }

        [JsonProperty("apparent_temperature_min")]
        public string ApparentTemperatureMin { get; set; }

        [JsonProperty("precipitation_sum")]
        public string PrecipitationSum { get; set; }

        [JsonProperty("precipitation_probability_max")]
        public string PrecipitationProbabilityMax { get; set; }

        public string AverageRelativeHumidity2m { get; set; }
    }
    public class DailyData
    {
        public string[] Time { get; set; }

        [JsonProperty("temperature_2m_max")]
        public double[] Temperature2mMax { get; set; }

        [JsonProperty("temperature_2m_min")]
        public double[] Temperature2mMin { get; set; }

        [JsonProperty("apparent_temperature_max")]
        public double[] ApparentTemperatureMax { get; set; }

        [JsonProperty("apparent_temperature_min")]
        public double[] ApparentTemperatureMin { get; set; }

        [JsonProperty("precipitation_sum")]
        public double[] PrecipitationSum { get; set; }

        [JsonProperty("precipitation_probability_max")]
        public int[] PrecipitationProbabilityMax { get; set; }

        public double[] AverageRelativeHumidity2m { get; set; }
    }

}