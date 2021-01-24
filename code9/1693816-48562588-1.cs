    public class ResponseObject
    {
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
        [JsonProperty("success")]
        public string SuccessText { get; set; }
        [JsonIgnore]
        public bool Success => SuccessText.Equals("yes", StringComparison.OrdinalIgnoreCase);
        [JsonProperty("awb")]
        public int[] Awb { get; set; }
    }
