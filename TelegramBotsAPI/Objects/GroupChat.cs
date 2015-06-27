using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotsAPI
{
    /// <summary>
    /// This object represents a group chat.
    /// </summary>
    public class GroupChat
    {
        /// <summary>
        /// Unique identifier for this group chat.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Group name.
        /// </summary>
        public string title { get; set; }

    }
}
