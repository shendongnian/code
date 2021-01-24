    public class ApiResponse
    {
        [JsonProperty("orderId")]
        public string orderId { get; set; }
        [JsonProperty("deposit")]
        public string deposit { get; set; }
        [JsonProperty("depositType")]
        public string depositType { get; set; }
        [JsonProperty("withdrawal")]
        public string withdrawal { get; set; }
        [JsonProperty("withdrawalType")]
        public string withdrawalType { get; set; }
    }
