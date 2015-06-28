using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TelegramBotsAPI
{
    public class BotApi
    {
        public string Token { get; private set; }
        public string BaseUrl { get { return "https://api.telegram.org/bot" + Token + "/"; } }
        private BotApi(string token)
        {
            Token = token;
        }

        public static BotApi GetInstance(string token)
        {
            return new BotApi(token);
        }

        /// <summary>
        /// A simple method for testing your bot's auth token. Requires no parameters. 
        /// </summary>
        /// <returns>Returns basic information about the bot in form of a User object.</returns>
        public User GetMe()
        {
            var request = (HttpWebRequest)WebRequest.Create(BaseUrl + "getMe");

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine(responseString);

            JObject json = JObject.Parse(responseString);
            if (json.GetValue("ok").ToString() == "true")
            {
                var user = JsonConvert.DeserializeObject<User>(json.GetValue("result").ToString());
                return user;
            }
            return null;
        }

        /// <summary>
        /// Use this method to send text messages. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="text">Text of the message to be sent.</param>
        /// <param name="disable_web_page_preview">Disables link previews for links in this message.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns></returns>
        public Message SendMessage(int chat_id, string text, bool disable_web_page_preview = false, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "sendMessage?text=" + text + "&chat_id=" + chat_id;
            if (disable_web_page_preview)
                url += "&disable_web_page_preview=true";
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Console.WriteLine(responseString);
            JObject json = JObject.Parse(responseString);
            if (json.GetValue("ok").ToString() == "true")
            {
                var message = JsonConvert.DeserializeObject<Message>(json.GetValue("result").ToString());
                return message;
            }
            return null;
        }

        /// <summary>
        /// Use this method to send text messages. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="text">Text of the message to be sent.</param>
        /// <param name="disable_web_page_preview">Disables link previews for links in this message.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns></returns>
        public Message SendMessage2(int chat_id, string text, bool disable_web_page_preview = false, int reply_to_message_id = -1, ReplyKeyboardMarkup reply_markup = null)
        {

            var request = (HttpWebRequest)WebRequest.Create(BaseUrl + "sendMessage");
            JObject body = new JObject();
            body.Add("chat_id", JToken.FromObject(chat_id));
            body.Add("text", JToken.FromObject(text));
            body.Add("disable_web_page_preview", JToken.FromObject(disable_web_page_preview));
            if (reply_to_message_id != -1)
                body.Add("reply_to_message_id", JToken.FromObject(reply_to_message_id));
            if (reply_markup != null)
                body.Add("reply_markup", JToken.FromObject(reply_markup));

            Console.WriteLine(body.ToString());

            //var response = (HttpWebResponse)request.GetResponse();

            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            //Console.WriteLine(responseString);

            //JObject json = JObject.Parse(responseString);
            //if (json.GetValue("ok").ToString() == "true")
            //{
            //    var message = JsonConvert.DeserializeObject<Message>(json.GetValue("result").ToString());
            //    return message;
            //}
            return null;
        }


        /// <summary>
        /// Use this method to send text messages. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="text">Text of the message to be sent.</param>
        /// <param name="disable_web_page_preview">Disables link previews for links in this message.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns></returns>
        public Message SendMessage3(int chat_id, string text, bool disable_web_page_preview = false, int reply_to_message_id = -1, ReplyKeyboardHide reply_markup = null)
        {
            return null;
        }


        /// <summary>
        /// Use this method to send text messages. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="text">Text of the message to be sent.</param>
        /// <param name="disable_web_page_preview">Disables link previews for links in this message.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <returns></returns>
        public Message SendMessage4(int chat_id, string text, bool disable_web_page_preview = false, int reply_to_message_id = -1, ForceReply reply_markup = null)
        {
            return null;
        }
    }
}
