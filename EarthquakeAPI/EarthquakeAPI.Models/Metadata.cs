using Newtonsoft.Json;

namespace EarthquakeAPI.Models
{
    public class Metadata
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
