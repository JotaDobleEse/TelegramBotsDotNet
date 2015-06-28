using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotsAPI
{
    [JsonObject()]
    public class MessageGroup : Message
    {
        /// <summary>
        /// Conversation the message belongs to — user in case of a private message, GroupChat in case of a group.
        /// </summary>
        [JsonProperty("chat")]
        public GroupChat chat { get; set; }
    }
}
