    public class Record
    {
        public Dictionary<string, string> Data { get; set; }
    
       [JsonProperty(PropertyName = "f_EMail")]
        public string Email
        {
            get;set;
        }    
    
        ...
    }
