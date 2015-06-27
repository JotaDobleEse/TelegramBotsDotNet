using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegramBotsAPI
{
    /// <summary>
    /// This object represents a general file (as opposed to photos and audio files). Telegram users can send files of any type of up to 1.5 GB in size.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Unique file identifier.
        /// </summary>
        public string file_id { get; set; }
        /// <summary>
        /// Document thumbnail as defined by sender.
        /// </summary>
        public PhotoSize thumb { get; set; }
        /// <summary>
        /// Optional. Original filename as defined by sender.
        /// </summary>
        public string file_name { get; set; }
        /// <summary>
        /// Optional. MIME type of the file as defined by sender.
        /// </summary>
        public string mime_type { get; set; }
        /// <summary>
        /// Optional. File size.
        /// </summary>
        public int file_size { get; set; }

    }
}
