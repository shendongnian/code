    public class Body
    { 
        [JsonConverter(typeof(StringEnumConverter))]
        public ContentType ContentType { get; set; }
        public string Content { get; set; }
    }
