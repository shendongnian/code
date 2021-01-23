    public class TransactionChangeLog
    {
        [JsonProperty(PropertyName = "transaction_id")]
        public int TransactionId { get; set; }
        [JsonProperty(PropertyName = "status")]
        public TransactionStatus Status { get; set; }
        [JsonProperty(PropertyName = "changelog")]
        [JsonConverter(typeof(ChangeLogConverter))]
        public ICollection<TransactionChange> Changelog { get; set; }
    }
