using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegramBotsAPI
{
    /// <summary>
    /// This object represents a general file (as opposed to photos and audio files). Telegram users can send files of any type of up to 1.5 GB in size.
    /// </summary>
    [JsonObject()]
    public class Document
    {
        /// <summary>
        /// Unique file identifier.
        /// </summary>
        [JsonProperty("file_id")]
        public string FileId { get; set; }
        /// <summary>
        /// Document thumbnail as defined by sender.
        /// </summary>
        [JsonProperty("thumb")]
        public PhotoSize Thumb { get; set; }
        /// <summary>
        /// Optional. Original filename as defined by sender.
        /// </summary>
        [JsonProperty("file_name")]
        public string FileName { get; set; }
        /// <summary>
        /// Optional. MIME type of the file as defined by sender.
        /// </summary>
        [JsonProperty("mime_type")]
        public string MimeType { get; set; }
        /// <summary>
        /// Optional. File size.
        /// </summary>
        [JsonProperty("file_size")]
        public int FileSize { get; set; }

    }
}
