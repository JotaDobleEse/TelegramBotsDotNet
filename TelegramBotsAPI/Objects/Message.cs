using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotsAPI
{
    /// <summary>
    /// This object represents a message.
    /// </summary>
    [JsonObject()]
    public class Message
    {
        /// <summary>
        /// Unique message identifier.
        /// </summary>
        [JsonProperty("message_id")]
        public int MessageId { get; set; }
        /// <summary>
        /// Sender.
        /// </summary>
        [JsonProperty("from")]
        public User From { get; set; }
        /// <summary>
        /// Conversation the message belongs to — user in case of a private message, GroupChat in case of a group.
        /// </summary>
        [JsonProperty("chat")]
        public GroupChat Chat { get; set; }
        /// <summary>
        /// Date the message was sent in Unix time.
        /// </summary>
        [JsonProperty("date")]
        public int Date { get; set; }
        /// <summary>
        /// Optional. For forwarded messages, sender of the original message.
        /// </summary>
        [JsonProperty("forward_from")]
        public User ForwardFrom { get; set; }
        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in Unix time.
        /// </summary>
        [JsonProperty("forward_date")]
        public int ForwardDate { get; set; }
        /// <summary>
        /// Optional. For replies, the original message. Note that the Message object in this field will not contain further reply_to_message fields even if it itself is a reply.
        /// </summary>
        [JsonProperty("reply_to_message")]
        public Message ReplyToMessage { get; set; }
        /// <summary>
        /// Optional. For text messages, the actual UTF-8 text of the message.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
        /// <summary>
        /// Optional. Message is an audio file, information about the file.
        /// </summary>
        [JsonProperty("audio")]
        public Audio Audio { get; set; }
        /// <summary>
        /// Optional. Message is a general file, information about the file.
        /// </summary>
        [JsonProperty("document")]
        public Document Document { get; set; }
        /// <summary>
        /// Optional. Message is a photo, available sizes of the photo.
        /// </summary>
        [JsonProperty("photo")]
        public PhotoSize[] Photo { get; set; }
        /// <summary>
        /// Optional. Message is a sticker, information about the sticker.
        /// </summary>
        [JsonProperty("sticker")]
        public Sticker Sticker { get; set; }
        /// <summary>
        /// Optional. Message is a video, information about the video.
        /// </summary>
        [JsonProperty("video")]
        public Video Video { get; set; }
        /// <summary>
        /// Optional. Message is a shared contact, information about the contact.
        /// </summary>
        [JsonProperty("contact")]
        public Contact Contact { get; set; }
        /// <summary>
        /// Optional. Message is a shared location, information about the location.
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
        /// <summary>
        /// Optional. A new member was added to the group, information about them (this member may be bot itself).
        /// </summary>
        [JsonProperty("new_chat_participant")]
        public User NewChatParticipant { get; set; }
        /// <summary>
        /// Optional. A member was removed from the group, information about them (this member may be bot itself).
        /// </summary>
        [JsonProperty("left_chat_participant")]
        public User LeftChatParticipant { get; set; }
        /// <summary>
        /// Optional. A group title was changed to this value.
        /// </summary>
        [JsonProperty("new_chat_title")]
        public string NewChatTitle { get; set; }
        /// <summary>
        /// Optional. A group photo was change to this value.
        /// </summary>
        [JsonProperty("new_chat_photo")]
        public PhotoSize[] NewChatPhoto { get; set; }
        /// <summary>
        /// Optional. Informs that the group photo was deleted.
        /// </summary>
        [JsonProperty("delete_chat_photo")]
        public bool DeleteChatPhoto { get; set; }
        /// <summary>
        /// Optional. Informs that the group has been created.
        /// </summary>
        [JsonProperty("group_chat_created")]
        public bool GroupChatCreated { get; set; }

    }
}
