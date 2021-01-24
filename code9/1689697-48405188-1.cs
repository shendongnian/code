    public class OrderBookResponse
    {
        [JsonProperty("bids")]
        public List<List<string>> Bids { get; set; }
        [JsonProperty("asks")]
        public List<List<string>> Asks { get; set; }
    }
