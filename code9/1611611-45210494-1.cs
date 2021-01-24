    public class GenericExample<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
    
    var ge = GenericExample<Response>();
