using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegramBotsAPI
{
    /// <summary>
    /// This object represents a phone contact.
    /// </summary>
    [JsonObject()]
    public class Contact
    {
        /// <summary>
        /// Contact's phone number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Contact's first name.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// Optional. Contact's last name.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// Optional. Contact's user identifier in Telegram.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
