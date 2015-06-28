﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegramBotsAPI
{
    /// <summary>
    /// This object represents a video file.
    /// </summary>
    [JsonObject()]
    public class Video
    {
        /// <summary>
        /// Unique identifier for this file.
        /// </summary>
        [JsonProperty("file_id")]
        public string FileId { get; set; }
        /// <summary>
        /// Video width as defined by sender.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }
        /// <summary>
        /// Video height as defined by sender.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }
        /// <summary>
        /// Duration of the video in seconds as defined by sender.
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }
        /// <summary>
        /// Video thumbnail.
        /// </summary>
        [JsonProperty("thumb")]
        public PhotoSize Thumb { get; set; }
        /// <summary>
        /// Optional. Mime type of a file as defined by sender.
        /// </summary>
        [JsonProperty("mime_type")]
        public string MimeType { get; set; }
        /// <summary>
        /// Optional. File size.
        /// </summary>
        [JsonProperty("file_size")]
        public int FileSize { get; set; }
        /// <summary>
        /// Optional. Text description of the video (usually empty).
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }
    }
}
