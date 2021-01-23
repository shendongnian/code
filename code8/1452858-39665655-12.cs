    public class Message
    {
        public List<Media> Items { get; set; }
    }
    
    public class Media
    {
        [JsonProperty("media")]
        private Dictionary<string, string> IdDict;
    
        public string Id
        {
            get { return IdDict["id"]; }
            set { IdDict["id"] = value; }
        }
    
    }
