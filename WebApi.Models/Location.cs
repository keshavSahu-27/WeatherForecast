using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WebApi.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; }

        [JsonProperty("feature_code")]
        public string FeatureCode { get; set; } = string.Empty;

        [JsonProperty("country_code")]
        public string CountryCode { get; set; } = string.Empty;

        [JsonProperty("admin1_id")]
        public int Admin1Id { get; set; }

        [JsonProperty("admin2_id")]
        public int Admin2Id { get; set; }
        public string Timezone { get; set; } = string.Empty;
        public int Population { get; set; }

        [JsonProperty("country_id")]
        public int CountryId { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Admin1 { get; set; } = string.Empty;
        public string Admin2 { get; set; } = string.Empty;
    }

}