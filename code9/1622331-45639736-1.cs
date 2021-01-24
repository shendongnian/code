    public class Envelope
    {
        public string Type { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(StringTypeConverter))]
        public Message InnerMessage { get; set; }
    }
    public class Message
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
    }
