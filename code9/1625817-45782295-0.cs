    public class MyRootNode
    {
        [JsonProperty(PropertyName = "action")]
        public string Action {get;set;}
        [JsonProperty(PropertyName = "myData")]
        public MyData Data {get;set;}
    }
    
    public class MyData
    {
        [JsonProperty(PropertyName = "name")]
        public string Name {get;set;}
    }
