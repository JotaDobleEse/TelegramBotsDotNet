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
    public enum MultimediaType
    {
        Photo, Audio, Document, Sticker, Video
    }
    public enum ChatActions
    {
        Typing, Upload_photo, Record_video, Upload_video, Record_audio, Upload_audio, Upload_document, Find_location
    }

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

        #region SendMessage
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
            return ParseResponseMessage(responseString);
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
        public Message SendMessage(int chat_id, string text, ReplyKeyboardMarkup reply_markup, bool disable_web_page_preview = false, int reply_to_message_id = -1)
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
            return ParseResponseMessage(responseString);
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
        public Message SendMessage(int chat_id, string text, ReplyKeyboardHide reply_markup, bool disable_web_page_preview = false, int reply_to_message_id = -1)
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
            return ParseResponseMessage(responseString);
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
        public Message SendMessage(int chat_id, string text, ForceReply reply_markup, bool disable_web_page_preview = false, int reply_to_message_id = -1)
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
            return ParseResponseMessage(responseString);
        }
        #endregion

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
            return ParseResponseMessage(responseString);
        }

        #region SendPhoto
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
            return SendMultimedia(chat_id, photo_path, MultimediaType.Photo, caption, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send photos. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_path">Photo to send. You can upload a new photo using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendPhoto(int chat_id, string photo_path, ReplyKeyboardMarkup reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, photo_path, MultimediaType.Photo, reply_markup, caption, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send photos. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_path">Photo to send. You can upload a new photo using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendPhoto(int chat_id, string photo_path, ReplyKeyboardHide reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, photo_path, MultimediaType.Photo, reply_markup, caption, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send photos. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_path">Photo to send. You can upload a new photo using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendPhoto(int chat_id, string photo_path, ForceReply reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, photo_path, MultimediaType.Photo, reply_markup, caption, reply_to_message_id);
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
            return ResendMultimedia(chat_id, photo_id, MultimediaType.Photo, caption, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send photos. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_id">Photo to send. You can pass a file_id as String to resend a photo that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendPhoto(int chat_id, string photo_id, ReplyKeyboardMarkup reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, photo_id, MultimediaType.Photo, reply_markup, caption, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send photos. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_id">Photo to send. You can pass a file_id as String to resend a photo that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendPhoto(int chat_id, string photo_id, ReplyKeyboardHide reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, photo_id, MultimediaType.Photo, reply_markup, caption, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send photos. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_id">Photo to send. You can pass a file_id as String to resend a photo that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendPhoto(int chat_id, string photo_id, ForceReply reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, photo_id, MultimediaType.Photo, reply_markup, caption, reply_to_message_id);
        }
        #endregion

        #region SendAudio
        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="audio_path">Audio file to send. You can upload a new audio file using multipart/form-data.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendAudio(int chat_id, string audio_path, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, audio_path, MultimediaType.Audio, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="audio_path">Audio file to send. You can upload a new audio file using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendAudio(int chat_id, string audio_path, ReplyKeyboardMarkup reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, audio_path, MultimediaType.Audio, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="audio_path">Audio file to send. You can upload a new audio file using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendAudio(int chat_id, string audio_path, ReplyKeyboardHide reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, audio_path, MultimediaType.Audio, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="audio_path">Audio file to send. You can upload a new audio file using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendAudio(int chat_id, string audio_path, ForceReply reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, audio_path, MultimediaType.Audio, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="audio_id">Audio file to send. You can pass a file_id as String to resend an audio that is already on the Telegram servers.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendAudio(int chat_id, string audio_id, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, audio_id, MultimediaType.Audio, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="audio_id">Audio file to send. You can pass a file_id as String to resend an audio that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendAudio(int chat_id, string audio_id, ReplyKeyboardMarkup reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, audio_id, MultimediaType.Audio, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="audio_id">Audio file to send. You can pass a file_id as String to resend an audio that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendAudio(int chat_id, string audio_id, ReplyKeyboardHide reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, audio_id, MultimediaType.Audio, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="audio_id">Audio file to send. You can pass a file_id as String to resend an audio that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendAudio(int chat_id, string audio_id, ForceReply reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, audio_id, MultimediaType.Audio, reply_markup, null, reply_to_message_id);
        }
        #endregion

        #region SendDocument
        /// <summary>
        /// Use this method to send general files. On success, the sent Message is returned. Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="document_path">File to send. You can upload a new file using multipart/form-data.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendDocument(int chat_id, string document_path, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, document_path, MultimediaType.Document, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send general files. On success, the sent Message is returned. Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="document_path">File to send. You can upload a new file using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendDocument(int chat_id, string document_path, ReplyKeyboardMarkup reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, document_path, MultimediaType.Document, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send general files. On success, the sent Message is returned. Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="document_path">File to send. You can upload a new file using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendDocument(int chat_id, string document_path, ReplyKeyboardHide reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, document_path, MultimediaType.Document, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send general files. On success, the sent Message is returned. Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="document_path">File to send. You can upload a new file using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendDocument(int chat_id, string document_path, ForceReply reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, document_path, MultimediaType.Document, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send general files. On success, the sent Message is returned. Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="document_id">File to send. You can pass a file_id as String to resend a file that is already on the Telegram servers.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendDocument(int chat_id, string document_id, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, document_id, MultimediaType.Document, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send general files. On success, the sent Message is returned. Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="document_id">File to send. You can pass a file_id as String to resend a file that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendDocument(int chat_id, string document_id, ReplyKeyboardMarkup reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, document_id, MultimediaType.Document, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send general files. On success, the sent Message is returned. Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="document_id">File to send. You can pass a file_id as String to resend a file that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendDocument(int chat_id, string document_id, ReplyKeyboardHide reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, document_id, MultimediaType.Document, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send general files. On success, the sent Message is returned. Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="document_id">File to send. You can pass a file_id as String to resend a file that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendDocument(int chat_id, string document_id, ForceReply reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, document_id, MultimediaType.Document, reply_markup, null, reply_to_message_id);
        }
        #endregion

        #region SendSticker
        /// <summary>
        /// Use this method to send .webp stickers. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="sticker_path">Sticker to send. You can upload a new sticker using multipart/form-data.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendSticker(int chat_id, string sticker_path, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, sticker_path, MultimediaType.Sticker, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send .webp stickers. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="sticker_path">Sticker to send. You can upload a new sticker using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendSticker(int chat_id, string sticker_path, ReplyKeyboardMarkup reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, sticker_path, MultimediaType.Sticker, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send .webp stickers. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="sticker_path">Sticker to send. You can upload a new sticker using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendSticker(int chat_id, string sticker_path, ReplyKeyboardHide reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, sticker_path, MultimediaType.Sticker, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send .webp stickers. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="sticker_path">Sticker to send. You can upload a new sticker using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendSticker(int chat_id, string sticker_path, ForceReply reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, sticker_path, MultimediaType.Sticker, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send .webp stickers. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="sticker_id">Sticker to send. You can pass a file_id as String to resend a sticker that is already on the Telegram servers.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendSticker(int chat_id, string sticker_id, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, sticker_id, MultimediaType.Sticker, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send .webp stickers. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="sticker_id">Sticker to send. You can pass a file_id as String to resend a sticker that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendSticker(int chat_id, string sticker_id, ReplyKeyboardMarkup reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, sticker_id, MultimediaType.Sticker, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send .webp stickers. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="sticker_id">Sticker to send. You can pass a file_id as String to resend a sticker that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendSticker(int chat_id, string sticker_id, ReplyKeyboardHide reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, sticker_id, MultimediaType.Sticker, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send .webp stickers. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="sticker_id">Sticker to send. You can pass a file_id as String to resend a sticker that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendSticker(int chat_id, string sticker_id, ForceReply reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, sticker_id, MultimediaType.Sticker, reply_markup, null, reply_to_message_id);
        }
        #endregion

        #region SendVideo
        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="video_path">Video file to send. You can upload a new video file using multipart/form-data.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendVideo(int chat_id, string video_path, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, video_path, MultimediaType.Video, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="video_path">Video file to send. You can upload a new video file using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendVideo(int chat_id, string video_path, ReplyKeyboardMarkup reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, video_path, MultimediaType.Video, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="video_path">Video file to send. You can upload a new video file using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendVideo(int chat_id, string video_path, ReplyKeyboardHide reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, video_path, MultimediaType.Video, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="video_path">Video file to send. You can upload a new video file using multipart/form-data.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendVideo(int chat_id, string video_path, ForceReply reply_markup, int reply_to_message_id = -1)
        {
            return SendMultimedia(chat_id, video_path, MultimediaType.Video, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="video_id">Video file to send. You can pass a file_id as String to resend an video that is already on the Telegram servers.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendVideo(int chat_id, string video_id, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, video_id, MultimediaType.Video, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="video_id">Video file to send. You can pass a file_id as String to resend an video that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendVideo(int chat_id, string video_id, ReplyKeyboardMarkup reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, video_id, MultimediaType.Video, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="video_id">Video file to send. You can pass a file_id as String to resend an video that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendVideo(int chat_id, string video_id, ReplyKeyboardHide reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, video_id, MultimediaType.Video, reply_markup, null, reply_to_message_id);
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). On success, the sent Message is returned. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="video_id">Video file to send. You can pass a file_id as String to resend an video that is already on the Telegram servers.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendVideo(int chat_id, string video_id, ForceReply reply_markup, int reply_to_message_id = -1)
        {
            return ResendMultimedia(chat_id, video_id, MultimediaType.Video, reply_markup, null, reply_to_message_id);
        }
        #endregion

        #region SendMultimedia
        /// <summary>
        /// Use this method to send multimedia files. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="file_path">File to send. You can upload a new file using multipart/form-data.</param>
        /// <param name="type">Type of file to send.</param>
        /// <param name="caption">Photo caption (only use with Type.Photo).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendMultimedia(int chat_id, string file_path, MultimediaType type, string caption = null, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "send" + type.ToString();

            byte[] file = null;
            using (var content = new MultipartFormDataContent("-------BotAPIDotNET"))
            {
                content.Add(new StringContent(string.Format("{0}", chat_id)), "chat_id");
                var fileStream = File.Open(file_path, FileMode.Open, FileAccess.Read);
                content.Add(new StreamContent(fileStream), type.ToString().ToLower(), file_path.Replace("\\", "/").Split('/').LastOrDefault());
                if (!string.IsNullOrEmpty(caption) && type == MultimediaType.Photo)
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

            using (Stream writer = request.GetRequestStream())
            {
                writer.Write(file, 0, file.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }

        /// <summary>
        /// Use this method to send multimedia files. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="file_path">File to send. You can upload a new file using multipart/form-data.</param>
        /// <param name="type">Type of file to send.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (only use with Type.Photo).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendMultimedia(int chat_id, string file_path, MultimediaType type, ReplyKeyboardMarkup reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "send" + type.ToString();

            byte[] file = null;
            using (var content = new MultipartFormDataContent("-------BotAPIDotNET"))
            {
                content.Add(new StringContent(string.Format("{0}", chat_id)), "chat_id");
                var fileStream = File.Open(file_path, FileMode.Open, FileAccess.Read);
                content.Add(new StreamContent(fileStream), type.ToString().ToLower(), file_path.Replace("\\", "/").Split('/').LastOrDefault());
                if (!string.IsNullOrEmpty(caption) && type == MultimediaType.Photo)
                    content.Add(new StringContent(caption), "caption");
                if (reply_to_message_id != -1)
                    content.Add(new StringContent(string.Format("{0}", reply_to_message_id)), "reply_to_message_id");
                if (reply_markup != null)
                    content.Add(new StringContent(JsonConvert.SerializeObject(reply_markup, Formatting.None)), "reply_markup");

                Stream multipart = content.ReadAsStreamAsync().Result;
                file = new byte[multipart.Length];
                multipart.Seek(0, SeekOrigin.Begin);
                multipart.Read(file, 0, (int)multipart.Length);
            }

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=\"-------BotAPIDotNET\"";
            request.Method = "POST";

            using (Stream writer = request.GetRequestStream())
            {
                writer.Write(file, 0, file.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }

        /// <summary>
        /// Use this method to send multimedia files. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="file_path">File to send. You can upload a new file using multipart/form-data.</param>
        /// <param name="type">Type of file to send.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (only use with Type.Photo).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendMultimedia(int chat_id, string file_path, MultimediaType type, ReplyKeyboardHide reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "send" + type.ToString();

            byte[] file = null;
            using (var content = new MultipartFormDataContent("-------BotAPIDotNET"))
            {
                content.Add(new StringContent(string.Format("{0}", chat_id)), "chat_id");
                var fileStream = File.Open(file_path, FileMode.Open, FileAccess.Read);
                content.Add(new StreamContent(fileStream), type.ToString().ToLower(), file_path.Replace("\\", "/").Split('/').LastOrDefault());
                if (!string.IsNullOrEmpty(caption) && type == MultimediaType.Photo)
                    content.Add(new StringContent(caption), "caption");
                if (reply_to_message_id != -1)
                    content.Add(new StringContent(string.Format("{0}", reply_to_message_id)), "reply_to_message_id");
                if (reply_markup != null)
                    content.Add(new StringContent(JsonConvert.SerializeObject(reply_markup, Formatting.None)), "reply_markup");

                Stream multipart = content.ReadAsStreamAsync().Result;
                file = new byte[multipart.Length];
                multipart.Seek(0, SeekOrigin.Begin);
                multipart.Read(file, 0, (int)multipart.Length);
            }

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=\"-------BotAPIDotNET\"";
            request.Method = "POST";

            using (Stream writer = request.GetRequestStream())
            {
                writer.Write(file, 0, file.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }

        /// <summary>
        /// Use this method to send multimedia files. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="file_path">File to send. You can upload a new file using multipart/form-data.</param>
        /// <param name="type">Type of file to send.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (only use with Type.Photo).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendMultimedia(int chat_id, string file_path, MultimediaType type, ForceReply reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "send" + type.ToString();

            byte[] file = null;
            using (var content = new MultipartFormDataContent("-------BotAPIDotNET"))
            {
                content.Add(new StringContent(string.Format("{0}", chat_id)), "chat_id");
                var fileStream = File.Open(file_path, FileMode.Open, FileAccess.Read);
                content.Add(new StreamContent(fileStream), type.ToString().ToLower(), file_path.Replace("\\", "/").Split('/').LastOrDefault());
                if (!string.IsNullOrEmpty(caption) && type == MultimediaType.Photo)
                    content.Add(new StringContent(caption), "caption");
                if (reply_to_message_id != -1)
                    content.Add(new StringContent(string.Format("{0}", reply_to_message_id)), "reply_to_message_id");
                if (reply_markup != null)
                    content.Add(new StringContent(JsonConvert.SerializeObject(reply_markup, Formatting.None)), "reply_markup");

                Stream multipart = content.ReadAsStreamAsync().Result;
                file = new byte[multipart.Length];
                multipart.Seek(0, SeekOrigin.Begin);
                multipart.Read(file, 0, (int)multipart.Length);
            }

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=\"-------BotAPIDotNET\"";
            request.Method = "POST";

            using (Stream writer = request.GetRequestStream())
            {
                writer.Write(file, 0, file.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }

        /// <summary>
        /// Use this method to send multimedia files. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_id">File to send. You can pass a file_id as String to resend a photo that is already on the Telegram servers.</param>
        /// <param name="type">Type of file to send.</param>
        /// <param name="caption">Photo caption (only use with Type.Photo).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendMultimedia(int chat_id, string photo_id, MultimediaType type, string caption = null, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "send" + type.ToString() + "?chat_id=" + chat_id + "&" + type.ToString().ToLower() + "=" + photo_id;
            if (!string.IsNullOrEmpty(caption) && type == MultimediaType.Photo)
                url += "&caption=" + caption;
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }

        /// <summary>
        /// Use this method to send multimedia files. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_id">File to send. You can pass a file_id as String to resend a photo that is already on the Telegram servers.</param>
        /// <param name="type">Type of file to send.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (only use with Type.Photo).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendMultimedia(int chat_id, string photo_id, MultimediaType type, ReplyKeyboardMarkup reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "send" + type.ToString() + "?chat_id=" + chat_id + "&" + type.ToString().ToLower() + "=" + photo_id;
            if (!string.IsNullOrEmpty(caption) && type == MultimediaType.Photo)
                url += "&caption=" + caption;
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;
            if (reply_markup != null)
                url += "&reply_markup=" + JsonConvert.SerializeObject(reply_markup, Formatting.None);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }

        /// <summary>
        /// Use this method to send multimedia files. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_id">File to send. You can pass a file_id as String to resend a photo that is already on the Telegram servers.</param>
        /// <param name="type">Type of file to send.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (only use with Type.Photo).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendMultimedia(int chat_id, string photo_id, MultimediaType type, ReplyKeyboardHide reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "send" + type.ToString() + "?chat_id=" + chat_id + "&" + type.ToString().ToLower() + "=" + photo_id;
            if (!string.IsNullOrEmpty(caption) && type == MultimediaType.Photo)
                url += "&caption=" + caption;
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;
            if (reply_markup != null)
                url += "&reply_markup=" + JsonConvert.SerializeObject(reply_markup, Formatting.None);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }

        /// <summary>
        /// Use this method to send multimedia files. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="photo_id">File to send. You can pass a file_id as String to resend a photo that is already on the Telegram servers.</param>
        /// <param name="type">Type of file to send.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="caption">Photo caption (only use with Type.Photo).</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message ResendMultimedia(int chat_id, string photo_id, MultimediaType type, ForceReply reply_markup, string caption = null, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "send" + type.ToString() + "?chat_id=" + chat_id + "&" + type.ToString().ToLower() + "=" + photo_id;
            if (!string.IsNullOrEmpty(caption) && type == MultimediaType.Photo)
                url += "&caption=" + caption;
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;
            if (reply_markup != null)
                url += "&reply_markup=" + JsonConvert.SerializeObject(reply_markup, Formatting.None);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }
        #endregion

        #region SendLocation
        /// <summary>
        /// Use this method to send point on the map. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="latitud">Latitude of location.</param>
        /// <param name="longitud">Longitude of location.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendLocation(int chat_id, float latitud, float longitud, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "sendLocation?chat_id=" + chat_id + "&latitud=" + latitud + "&longitud=" + longitud;
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }

        /// <summary>
        /// Use this method to send point on the map. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="latitud">Latitude of location.</param>
        /// <param name="longitud">Longitude of location.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendLocation(int chat_id, float latitud, float longitud, ReplyKeyboardMarkup reply_markup, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "sendLocation?chat_id=" + chat_id + "&latitud=" + latitud + "&longitud=" + longitud;
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;
            if (reply_markup != null)
                url += "&reply_markup=" + JsonConvert.SerializeObject(reply_markup, Formatting.None);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }

        /// <summary>
        /// Use this method to send point on the map. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="latitud">Latitude of location.</param>
        /// <param name="longitud">Longitude of location.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendLocation(int chat_id, float latitud, float longitud, ReplyKeyboardHide reply_markup, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "sendLocation?chat_id=" + chat_id + "&latitud=" + latitud + "&longitud=" + longitud;
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;
            if (reply_markup != null)
                url += "&reply_markup=" + JsonConvert.SerializeObject(reply_markup, Formatting.None);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }

        /// <summary>
        /// Use this method to send point on the map. On success, the sent Message is returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="latitud">Latitude of location.</param>
        /// <param name="longitud">Longitude of location.</param>
        /// <param name="reply_markup">Additional interface options. A JSON-serialized object for a custom reply keyboard, instructions to hide keyboard or to force a reply from the user.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message.</param>
        /// <returns></returns>
        public Message SendLocation(int chat_id, float latitud, float longitud, ForceReply reply_markup, int reply_to_message_id = -1)
        {
            string url = BaseUrl + "sendLocation?chat_id=" + chat_id + "&latitud=" + latitud + "&longitud=" + longitud;
            if (reply_to_message_id != -1)
                url += "&reply_to_message_id=" + reply_to_message_id;
            if (reply_markup != null)
                url += "&reply_markup=" + JsonConvert.SerializeObject(reply_markup, Formatting.None);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return ParseResponseMessage(responseString);
        }
        #endregion

        /// <summary>
        /// Use this method when you need to tell the user that something is happening on the bot's side. The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status).
        /// We only recommend using this method when a response from the bot will take a noticeable amount of time to arrive.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the message recipient — User or GroupChat id.</param>
        /// <param name="action">Type of action to broadcast. Choose one, depending on what the user is about to receive: typing for text messages, upload_photo for photos, record_video or upload_video for videos, record_audio or upload_audio for audio files, upload_document for general files, find_location for location data.</param>
        public void SendChatAction(int chat_id, ChatActions action)
        {
            string url = BaseUrl + "sendChatAction?chat_id=" + chat_id + "&action=" + action.ToString().ToLower();

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var response = (HttpWebResponse)request.GetResponse();
        }

        public UserProfilePhotos GetUserProfilePhotos(int user_id, int offset = -1, int limit = 100)
        {
            if (limit > 100 || limit < 1)
                throw new ArgumentOutOfRangeException("limit", limit, "limit value should be between 1 and 100");

            string url = BaseUrl + "getUserProfilePhotos?user_id=" + user_id;
            if (offset != -1)
                url += "&offset=" + offset;
            if (limit != 100)
                url += "&limit=" + limit;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject json = JObject.Parse(responseString);
            Console.WriteLine(json.ToString());
            if (json.GetValue("ok").ToString().ToLower() == "true")
            {
                try
                {
                    var userProfilePhotos = JsonConvert.DeserializeObject<UserProfilePhotos>(json.GetValue("result").ToString());
                    return userProfilePhotos;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return null;
        }

        private Message ParseResponseMessage(string response)
        {
            JObject json = JObject.Parse(response);
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
