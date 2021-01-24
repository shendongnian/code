    public class Response
    {
        [JsonProperty("COMPLETED_COUNT")]
        public int CompletedCount { get; set; }
        
        [JsonProperty("INPROGRESS_COUNT")]
        public int InProgressCount { get; set; }
        
        [JsonProperty("FAILED_COUNT")]
        public int FailedCount { get; set; }
    
        [JsonExtensionData]
        public Dictionary<string, object> ExtraData { get; } = new Dictionary<string, object>();
    }
