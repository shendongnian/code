    public class Disbursement
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("contactId")]
        public string ContactId { get; set; }
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("category")]
        public int Category { get; set; }
    }
