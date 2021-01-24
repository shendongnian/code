    public class Response<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    
        [JsonProperty("data")]
        public T Data { get; set; }
    }
