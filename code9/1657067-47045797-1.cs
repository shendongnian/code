    [JsonConverter(typeof(MyRequestConverter))]
    public class MyRequest
    {
        public string Type { get; set; }
        public string Source { get; set; }
    }
