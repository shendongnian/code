    [JsonIgnore]
        public List<Something> Somethings { get; set; }
    
     //Ignore by default
        public List<Something> Somethings { get; set; }
    
    JsonConvert.SerializeObject(myObject, 
                                Newtonsoft.Json.Formatting.None, 
                                new JsonSerializerSettings { 
                                    NullValueHandling = NullValueHandling.Ignore
                                });
