    class MyType 
    {
        public MyType()
        {
            JsonData = new Dictionary<string, object>();
        }
        [JsonExtensionData]
        public Dictionary<string, object> JsonData { get; set;}
    
        public string OtherProperty { get; set; }
    }
