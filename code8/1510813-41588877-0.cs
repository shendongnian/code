    public class First
    {
        [JsonProperty("FirstBool")]
        public int FirstBool { get; set; }
    
        [JsonProperty("aString")]
        public string aString { get; set; }
    }      
    
    public class ClsResult
    {
        [JsonProperty("First")]
        public First First { get; set; }    
    
        [JsonProperty("BadGuy")] 
        public string BadGuy { get; set; }
    }
