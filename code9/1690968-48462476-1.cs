    public class Response
    {
        public DateTime time { get; set; }
        public string event_name { get; set; }
        public string event_type { get; set; }
        public string method { get; set; }
    
        [JsonConverter(typeof(EmbeddedJsonConverter))]
        public MessageDetails message_details { get; set; }
    }
