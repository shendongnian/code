    public class Zero
        {
    
            [JsonProperty("prop1")]
            public int Prop1 { get; set; }
    
            [JsonProperty("prop2")]
            public string Prop2 { get; set; }
        }
    
        public class One
        {
    
            [JsonProperty("prop1")]
            public int Prop1 { get; set; }
    
            [JsonProperty("prop2")]
            public string Prop2 { get; set; }
        }
    
        public class Categories
        {
    
            [JsonProperty("0")]
            public Zero Zero { get; set; }
    
            [JsonProperty("1")]
            public One One { get; set; }
        }
    
        public class Data
        {
    
            [JsonProperty("categories")]
            public Categories Categories { get; set; }
        }
    
        public class Example
        {
    
            [JsonProperty("code")]
            public int Code { get; set; }
    
            [JsonProperty("message")]
            public string Message { get; set; }
    
            [JsonProperty("data")]
            public Data Data { get; set; }
        }
