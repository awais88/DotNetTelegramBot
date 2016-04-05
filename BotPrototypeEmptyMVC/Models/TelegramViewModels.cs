using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPrototypeEmptyMVC.Models
{
    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class TelegramWebhookUpdate
    {
        public int update_id { get; set; }
        public Message message { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class Message
    {
        public int message_id { get; set; }
        public User from { get; set; }
        public int date { get; set; }
        public Chat chat { get; set; }
        public User forward_from { get; set; }
        public int forward_date { get; set; }
        public Message reply_to_message { get; set; }
        public string text { get; set; }
        public Audio audio { get; set; }
        public Document document { get; set; }
        public PhotoSize[] photo { get; set; }
        public Sticker sticker { get; set; }
        public Video video { get; set; }
        public Voice voice { get; set; }
        public string caption { get; set; }
        public Contact contact { get; set; }
        public Location location { get; set; }
        public User new_chat_participant { get; set; }
        public User left_chat_participant { get; set; }
        public string new_chat_title { get; set; }
        public PhotoSize[] new_chat_photo { get; set; }
        public bool delete_chat_photo { get; set; }
        public bool group_chat_created { get; set; }
        public bool supergroup_chat_created { get; set; }
        public bool channel_chat_created { get; set; }
        public int migrate_to_chat_id { get; set; }
        public int migrate_from_chat_id { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class User
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class Chat
    {
        public int id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class Audio
    {
        public string file_id { get; set; }
        public int duration { get; set; }
        public string performer { get; set; }
        public string title { get; set; }
        public string mime_type { get; set; }
        public int file_size { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class Document
    {
        public string file_id { get; set; }
        public PhotoSize thumb { get; set; }
        public string file_name { get; set; }
        public string mime_type { get; set; }
        public int file_size { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class PhotoSize
    {
        public string file_id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int file_size { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class Sticker
    {
        public string file_id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public PhotoSize thumb { get; set; }
        public int file_size { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class Video
    {
        public string file_id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int duration { get; set; }
        public PhotoSize thumb { get; set; }
        public string mime_type { get; set; }
        public int file_size { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class Voice
    {
        public string file_id { get; set; }
        public int duration { get; set; }
        public string mime_type { get; set; }
        public int file_size { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class Contact
    {
        public string phone_number { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int user_id { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class Location
    {
        public float longitude { get; set; }
        public float latitude { get; set; }
    }

    /// <summary>
    /// Telegram specific classe designed with the help of Telegram BOT development guidelines
    /// </summary>
    public class SendMessageObject
    {
        public string chat_id { get; set; }
        public string text { get; set; }
        public string parse_mode { get; set; }
        public bool disable_web_page_preview { get; set; }
        public int reply_to_message_id { get; set; }
    }
}
