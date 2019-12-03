using System;
using Newtonsoft.Json;

namespace ISTAT.Data
{
    public class GeoResponse
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        public GeoResponse()
        {
        }
    }
}
