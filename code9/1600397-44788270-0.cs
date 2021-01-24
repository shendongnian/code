    public class RootObject
    {
        [JsonProperty("Key")]
        public string key {get;set;}
     
        [JsonProperty("Value")]   
        public List<EpaSccCodeModel> Value {get;set;}
    }
    
