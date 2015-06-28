using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegramBotsAPI
{
    /// <summary>
    /// This object represents a sticker.
    /// </summary>
    [JsonObject()]
    public class Sticker
    {
        /// <summary>
        /// Unique identifier for this file.
        /// </summary>
        [JsonProperty("file_id")]
        public string FileId { get; set; }
        /// <summary>
        /// Sticker width.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }
        /// <summary>
        /// Sticker height.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }
        /// <summary>
        /// Sticker thumbnail in .webp or .jpg format.
        /// </summary>
        [JsonProperty("thumb")]
        public PhotoSize Thumb { get; set; }
        /// <summary>
        /// Optional. File size.
        /// </summary>
        [JsonProperty("file_size")]
        public int FileSize { get; set; }
    }
}
