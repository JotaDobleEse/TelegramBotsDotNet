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
using System.Runtime.Serialization;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace TelegramBotsAPI
{
    public class BotApi
    {
        public string Token { get; private set; }
        public string BaseUrl { get { return "https://api.telegram.org/bot" + Token + "/"; } }
        public BotApi(string token)
        {
            Token = token;
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
            if (json.GetValue("ok").ToString().ToLower() == "true")
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
            JObject json = JObject.Parse(responseString);
            Console.WriteLine(json.ToString());
            if (json.GetValue("ok").ToString().ToLower() == "true")
            {
                try
                {
                    Message message = JsonConvert.DeserializeObject<Message>(json.GetValue("result").ToString());
                    return message;
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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
        public Message SendMessageAndShowKeyboard(int chat_id, string text, ReplyKeyboardMarkup reply_markup, bool disable_web_page_preview = false, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "sendMessage?text=" + text + "&chat_id=" + chat_id;
            if (disable_web_page_preview)
                url += "&disable_web_page_preview=true";
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;
            if (reply_markup != null)
                url += "&reply_markup=" + JsonConvert.SerializeObject(reply_markup, Formatting.None);

            Console.WriteLine(url);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(responseString);
            Console.WriteLine(json.ToString());
            if (json.GetValue("ok").ToString().ToLower() == "true")
            {
                try
                {
                    Message message = JsonConvert.DeserializeObject<Message>(json.GetValue("result").ToString());
                    return message;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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
        public Message SendMessageAndHideKeyboard(int chat_id, string text, ReplyKeyboardHide reply_markup, bool disable_web_page_preview = false, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "sendMessage?text=" + text + "&chat_id=" + chat_id;
            if (disable_web_page_preview)
                url += "&disable_web_page_preview=true";
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;
            if (reply_markup != null)
                url += "&reply_markup=" + JsonConvert.SerializeObject(reply_markup, Formatting.None);

            Console.WriteLine(url);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(responseString);
            Console.WriteLine(json.ToString());
            if (json.GetValue("ok").ToString().ToLower() == "true")
            {
                try
                {
                    Message message = JsonConvert.DeserializeObject<Message>(json.GetValue("result").ToString());
                    return message;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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
        public Message SendMessageAndForceReply(int chat_id, string text, ForceReply reply_markup, bool disable_web_page_preview = false, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "sendMessage?text=" + text + "&chat_id=" + chat_id;
            if (disable_web_page_preview)
                url += "&disable_web_page_preview=true";
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;
            if (reply_markup != null)
                url += "&reply_markup=" + JsonConvert.SerializeObject(reply_markup, Formatting.None);

            Console.WriteLine(url);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(responseString);
            Console.WriteLine(json.ToString());
            if (json.GetValue("ok").ToString().ToLower() == "true")
            {
                try
                {
                    Message message = JsonConvert.DeserializeObject<Message>(json.GetValue("result").ToString());
                    return message;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return null;
        }

        /// <summary>
        /// Use this method to forward messages of any kind. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="from_chat_id">Unique identifier for the chat where the original message was sent — User or GroupChat id.</param>
        /// <param name="message_id">Unique message identifier</param>
        /// <returns></returns>
        public Message ForwardMessage(int chat_id, int from_chat_id, int message_id)
        {
            string url = BaseUrl + "forwardMessage?chat_id=" + chat_id + "&from_chat_id=" + from_chat_id + "&message_id=" + message_id;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(responseString);
            Console.WriteLine(json.ToString());
            if (json.GetValue("ok").ToString().ToLower() == "true")
            {
                try
                {
                    Message message = JsonConvert.DeserializeObject<Message>(json.GetValue("result").ToString());
                    return message;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return null;
        }

        /// <summary>
        /// Use this method to send photos. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_path">Photo to send. You can upload a new photo using multipart/form-data.</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendPhoto(int chat_id, string photo_path, string caption = null, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "sendPhoto";

            byte[] file = null;
            using (var content = new MultipartFormDataContent("-------BotAPIDotNET"))
            {
                content.Add(new StringContent(string.Format("{0}", chat_id)), "chat_id");
                var fileStream = File.Open(photo_path, FileMode.Open, FileAccess.Read);
                content.Add(new StreamContent(fileStream), "photo", photo_path.Replace("\\", "/").Split('/').LastOrDefault());
                if (!string.IsNullOrEmpty(caption))
                    content.Add(new StringContent(caption), "caption");
                if (reply_to_message_id != -1)
                    content.Add(new StringContent(string.Format("{0}", reply_to_message_id)), "reply_to_message_id");

                Stream multipart = content.ReadAsStreamAsync().Result;
                file = new byte[multipart.Length];
                multipart.Seek(0, SeekOrigin.Begin);
                multipart.Read(file, 0, (int)multipart.Length);
            }

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=\"-------BotAPIDotNET\"";
            request.Method = "POST";

            using(Stream writer = request.GetRequestStream())
            {
                writer.Write(file, 0, file.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(responseString);
            Console.WriteLine(json.ToString());
            if (json.GetValue("ok").ToString().ToLower() == "true")
            {
                try
                {
                    Message message = JsonConvert.DeserializeObject<Message>(json.GetValue("result").ToString());
                    return message;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return null;
        }

        /// <summary>
        /// Use this method to send photos. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_id">Photo to send. You can pass a file_id as String to resend a photo that is already on the Telegram servers.</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendPhoto(int chat_id, string photo_id, string caption = null, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "sendPhoto?chat_id=" + chat_id + "&photo=" + photo_id;
            if (!string.IsNullOrEmpty(caption))
                url += "&caption=" + caption;
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(responseString);
            Console.WriteLine(json.ToString());
            if (json.GetValue("ok").ToString().ToLower() == "true")
            {
                try
                {
                    Message message = JsonConvert.DeserializeObject<Message>(json.GetValue("result").ToString());
                    return message;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return null;
        }


    }
}
