     public class From
    {
        public int id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
        public string language_code { get; set; }
    }
    public class Chat
    {
        public long id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string username { get; set; }
    }
    public class ForwardFromChat
    {
        public long id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
    }
    public class Document
    {
        public string file_name { get; set; }
        public string mime_type { get; set; }
        public string file_id { get; set; }
        public int file_size { get; set; }
    }
    public class Audio
    {
        public int duration { get; set; }
        public string mime_type { get; set; }
        public string title { get; set; }
        public string performer { get; set; }
        public string file_id { get; set; }
        public int file_size { get; set; }
    }
    public class Photo
    {
        public string file_id { get; set; }
        public int file_size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
    public class Video
    {
        public int duration { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string mime_type { get; set; }
        public Thumb thumb { get; set; }
        public string file_id { get; set; }
        public int file_size { get; set; }
    }
    public class Thumb
    {
        public string file_id { get; set; }
        public int file_size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
    public class Message
    {
        public int message_id { get; set; }
        public From from { get; set; }
        public Chat chat { get; set; }
        public int date { get; set; }
        public string text { get; set; }
    }
    public class CaptionEntity
    {
        public int offset { get; set; }
        public int length { get; set; }
        public string type { get; set; }
    }
    public class EditedChannelPost
    {
        public int message_id { get; set; }
        public Chat chat { get; set; }
        public int date { get; set; }
        public int edit_date { get; set; }
        public string caption { get; set; }
        public List<CaptionEntity> caption_entities { get; set; }
        public string text { get; set; }
        public Document document { get; set; }
        public Video video { get; set; }
        public Audio audio { get; set; }
        public List<Photo> photo { get; set; }
    }
    public class ChannelPost
    {
        public int message_id { get; set; }
        public Chat chat { get; set; }
        public int date { get; set; }
        public ForwardFromChat forward_from_chat { get; set; }
        public int forward_from_message_id { get; set; }
        public string forward_signature { get; set; }
        public int forward_date { get; set; }
        public string caption { get; set; }
        public string text { get; set; }
        public List<CaptionEntity> caption_entities { get; set; }
        public Document document { get; set; }
        public Video video { get; set; }
        public Audio audio { get; set; }
        public List<Photo> photo { get; set; }
    }
    public class RootObject
    {
        public long update_id { get; set; }
        public ChannelPost channel_post { get; set; }
        public EditedChannelPost edited_channel_post { get; set; }
        public Message message { get; set; }
    }
