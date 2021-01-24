    public class Attachment
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("filename")]
        public string Filename { get; set; }
    }
    public class AccountDetails
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("check_number")]
        public int CheckNumber { get; set; }
        [JsonProperty("payment_number")]
        public int PaymentNumber { get; set; }
        [JsonProperty("attachments")]
        public IList<Attachment> Attachments { get; set; }
    }
