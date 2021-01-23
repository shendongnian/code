    public class Response
    {   [JsonProperty("@type")]
        public string Type { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("Token")]
        public string Token { get; set; }
        [JsonProperty("AppId")]
        public int? AppId { get; set; }
        [JsonProperty("Available")]
        public string Available { get; set; }
    }
    public class Log
    {
        public List<Response> Response { get; set; }
    }
    public class RootObject
    {
        public Log log { get; set; }
    }
