    public class OrderBookResponse
    {
        [JsonProperty("bids")]
        public List<List<string>> Bids { get; set; }
    }
