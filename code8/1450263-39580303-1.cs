    public class Info
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    
        [JsonProperty("error")]
        public string Error { get; set; }
    }
    
    public class Result
    {
    	[JsonProperty("code")]
        public string Code { get; set; }
    
        [JsonProperty("version")]
        public string Version { get; set; }
    }
