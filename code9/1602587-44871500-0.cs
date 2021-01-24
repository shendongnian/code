        class Program
        {
            private static void Main(string[] args)
            {
                var myObj = JsonConvert.DeserializeObject<JsonDef>(json);
    
                Console.Read();
            }
        }
    
        public class Preview
        {
    
            [JsonProperty("small")]
            public string small { get; set; }
    
            [JsonProperty("medium")]
            public string medium { get; set; }
    
            [JsonProperty("large")]
            public string large { get; set; }
    
            [JsonProperty("template")]
            public string template { get; set; }
        }
    
        public class Channel
        {
    
            [JsonProperty("mature")]
            public bool mature { get; set; }
    
            [JsonProperty("status")]
            public string status { get; set; }
    
            [JsonProperty("broadcaster_language")]
            public string broadcaster_language { get; set; }
    
            [JsonProperty("display_name")]
            public string display_name { get; set; }
    
            [JsonProperty("game")]
            public string game { get; set; }
    
            [JsonProperty("language")]
            public string language { get; set; }
    
            [JsonProperty("_id")]
            public int _id { get; set; }
    
            [JsonProperty("name")]
            public string name { get; set; }
    
            [JsonProperty("created_at")]
            public DateTime created_at { get; set; }
    
            [JsonProperty("updated_at")]
            public DateTime updated_at { get; set; }
    
            [JsonProperty("partner")]
            public bool partner { get; set; }
    
            [JsonProperty("logo")]
            public string logo { get; set; }
    
            [JsonProperty("video_banner")]
            public string video_banner { get; set; }
    
            [JsonProperty("profile_banner")]
            public string profile_banner { get; set; }
    
            [JsonProperty("profile_banner_background_color")]
            public string profile_banner_background_color { get; set; }
    
            [JsonProperty("url")]
            public string url { get; set; }
    
            [JsonProperty("views")]
            public int views { get; set; }
    
            [JsonProperty("followers")]
            public int followers { get; set; }
    
            [JsonProperty("broadcaster_type")]
            public string broadcaster_type { get; set; }
    
            [JsonProperty("description")]
            public string description { get; set; }
        }
    
        public class Stream
        {
    
            [JsonProperty("_id")]
            public long _id { get; set; }
    
            [JsonProperty("game")]
            public string game { get; set; }
    
            [JsonProperty("broadcast_platform")]
            public string broadcast_platform { get; set; }
    
            [JsonProperty("community_id")]
            public string community_id { get; set; }
    
            [JsonProperty("community_ids")]
            public IList<string> community_ids { get; set; }
    
            [JsonProperty("viewers")]
            public int viewers { get; set; }
    
            [JsonProperty("video_height")]
            public int video_height { get; set; }
    
            [JsonProperty("average_fps")]
            public double average_fps { get; set; }
    
            [JsonProperty("delay")]
            public int delay { get; set; }
    
            [JsonProperty("created_at")]
            public DateTime created_at { get; set; }
    
            [JsonProperty("is_playlist")]
            public bool is_playlist { get; set; }
    
            [JsonProperty("stream_type")]
            public string stream_type { get; set; }
    
            [JsonProperty("preview")]
            public Preview preview { get; set; }
    
            [JsonProperty("channel")]
            public Channel channel { get; set; }
        }
    
        public class JsonDef
        {
    
            [JsonProperty("stream")]
            public Stream stream { get; set; }
        }
