using System;
using EarthquakeAPI.Models.utils;
using Newtonsoft.Json;

namespace EarthquakeAPI.Models
{
    public class Property
    {
        [JsonProperty("mag")]
        public double Mag { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime Time { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("DepthMin")]
        public double? DepthMin { get; set; }
    }
}
