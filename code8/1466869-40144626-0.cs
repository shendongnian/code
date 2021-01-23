    public class TransactionChangeLog
    {
        [JsonProperty(PropertyName = "transaction_id")]
        public int TransactionId { get; set; }
        [JsonProperty(PropertyName = "status")]
        public TransactionStatus Status { get; set; }
        [JsonProperty(PropertyName = "changelog")]
        public Dictionary<DateTime, Dictionary<string, TransactionChange>> Changelog { get; set; }
    }
    public class TransactionChange
    {
        public string From { get; set; }
        public string To { get; set; }
    }
