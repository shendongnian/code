    var reply = activity.CreateReply();
    reply.ChannelData = new TelegramCustomMessage
    {
        Method = "sendLocation",
        Parameters = new Parameters
        {
            ChatId = "your_chat_id",
            Latitute = 0,
            Longitute = 0
        }
    };
    
    public class TelegramCustomMessage
    {
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }
        [JsonProperty(PropertyName = "parameters")]
        public Parameters Parameters { get; set; }
    }
    
    public class Parameters
    {
        [JsonProperty(PropertyName = "chat_id")]
        public string ChatId { get; set; }
        [JsonProperty(PropertyName = "latitute")]
        public float Latitute { get; set; }
        [JsonProperty(PropertyName = "longitute")]
        public float Longitute { get; set; }
    }
