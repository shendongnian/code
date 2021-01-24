    public class JsonRoot
    {
        public string type { get; set; }
        public string format { get; set; }
        public string version { get; set; }
        [JsonProperty("data")]
        public Dictionary<string, HeroesData> heroes { get; set; }
    }
