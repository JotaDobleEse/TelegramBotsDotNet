using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegramBotsAPI
{
    /// <summary>
    /// This object represents a video file.
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Unique identifier for this file.
        /// </summary>
        public string file_id { get; set; }
        /// <summary>
        /// Video width as defined by sender.
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// Video height as defined by sender.
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// Duration of the video in seconds as defined by sender.
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// Video thumbnail.
        /// </summary>
        public PhotoSize thumb { get; set; }
        /// <summary>
        /// Optional. Mime type of a file as defined by sender.
        /// </summary>
        public string mime_type { get; set; }
        /// <summary>
        /// Optional. File size.
        /// </summary>
        public int file_size { get; set; }
        /// <summary>
        /// Optional. Text description of the video (usually empty).
        /// </summary>
        public string caption { get; set; }
    }
}
