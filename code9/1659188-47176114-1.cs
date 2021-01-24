    public static ResponseBase Classify(string json)
    {
        var response = JsonConvert.DeserializeObject<ResponseBase>(json);
        
        if (response.ExtraData.ContainsKey("Results"))
            return JsonConvert.DeserializeObject<ResponseWithResults>(json);
            
        return response;
    }
    
    public class ResponseBase
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
    
    public class ResponseWithResults : ResponseBase
    {
        public int BatchId { get; set; }
        public List<ResponseResult> Results { get; } = new List<ResponseResult>();
    }
    
    public class ResponseResult
    {
        public int ItemId { get; set; }
        public string ResultMessage { get; set; }
    }
