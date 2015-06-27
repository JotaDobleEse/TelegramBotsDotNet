using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegramBotsAPI
{
    /// <summary>
    /// This object represents a sticker.
    /// </summary>
    public class Sticker
    {
        /// <summary>
        /// Unique identifier for this file.
        /// </summary>
        public string file_id { get; set; }
        /// <summary>
        /// Sticker width.
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// Sticker height.
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// Sticker thumbnail in .webp or .jpg format.
        /// </summary>
        public PhotoSize thumb { get; set; }
        /// <summary>
        /// Optional. File size.
        /// </summary>
        public int file_size { get; set; }
    }
}
