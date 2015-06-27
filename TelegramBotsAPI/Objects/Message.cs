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
    public class Message
    {
        /// <summary>
        /// Unique message identifier.
        /// </summary>
        public int message_id { get; set; }
        /// <summary>
        /// Sender.
        /// </summary>
        public User from { get; set; }
        /// <summary>
        /// Date the message was sent in Unix time.
        /// </summary>
        public int date { get; set; }
        /// <summary>
        /// Conversation the message belongs to — user in case of a private message, GroupChat in case of a group.
        /// </summary>
        public GroupChat chat { get; set; }
        /// <summary>
        /// Optional. For forwarded messages, sender of the original message.
        /// </summary>
        public User forward_from { get; set; }
        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in Unix time.
        /// </summary>
        public int forward_date { get; set; }
        /// <summary>
        /// Optional. For replies, the original message. Note that the Message object in this field will not contain further reply_to_message fields even if it itself is a reply.
        /// </summary>
        public Message reply_to_message { get; set; }
        /// <summary>
        /// Optional. For text messages, the actual UTF-8 text of the message.
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// Optional. Message is an audio file, information about the file.
        /// </summary>
        public Audio audio { get; set; }
        /// <summary>
        /// Optional. Message is a general file, information about the file.
        /// </summary>
        public Document document { get; set; }
        /// <summary>
        /// Optional. Message is a photo, available sizes of the photo.
        /// </summary>
        public PhotoSize[] photo { get; set; }
        /// <summary>
        /// Optional. Message is a sticker, information about the sticker.
        /// </summary>
        public Sticker sticker { get; set; }
        /// <summary>
        /// Optional. Message is a video, information about the video.
        /// </summary>
        public Video video { get; set; }
        /// <summary>
        /// Optional. Message is a shared contact, information about the contact.
        /// </summary>
        public Contact contact { get; set; }
        /// <summary>
        /// Optional. Message is a shared location, information about the location.
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// Optional. A new member was added to the group, information about them (this member may be bot itself).
        /// </summary>
        public User new_chat_participant { get; set; }
        /// <summary>
        /// Optional. A member was removed from the group, information about them (this member may be bot itself).
        /// </summary>
        public User left_chat_participant { get; set; }
        /// <summary>
        /// Optional. A group title was changed to this value.
        /// </summary>
        public string new_chat_title { get; set; }
        /// <summary>
        /// Optional. A group photo was change to this value.
        /// </summary>
        public PhotoSize[] new_chat_photo { get; set; }
        /// <summary>
        /// Optional. Informs that the group photo was deleted.
        /// </summary>
        public bool delete_chat_photo { get; set; }
        /// <summary>
        /// Optional. Informs that the group has been created.
        /// </summary>
        public bool group_chat_created { get; set; }

    }
}
