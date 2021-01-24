    public class FineModel
    {
        [JsonProperty]
        public String officer { get; internal set; }
        [JsonProperty]
        public String target { get; internal set; }
        [JsonProperty]
        public int amount { get; internal set; }
        [JsonProperty]
        public String reason { get; internal set; }
        [JsonProperty]
        public String date { get; internal set; }
            
        public FineModel() { }
    }
