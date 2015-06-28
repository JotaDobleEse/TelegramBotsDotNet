using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegramBotsAPI
{
    /// <summary>
    /// This object represents a point on the map.
    /// </summary>
    [JsonObject()]
    public class Location
    {
        /// <summary>
        /// Longitude as defined by sender.
        /// </summary>
        [JsonProperty("longitude")]
        public float Longitude { get; set; }
        /// <summary>
        /// Latitude as defined by sender.
        /// </summary>
        [JsonProperty("latitude")]
        public float Latitude { get; set; }
    }
}
