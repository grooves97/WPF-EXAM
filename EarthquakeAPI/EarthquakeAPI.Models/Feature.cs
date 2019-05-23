using Newtonsoft.Json;

namespace EarthquakeAPI.Models
{
    public class Feature
    {
        [JsonProperty("properties")]
        public Property properties { get; set; }
    }
}
