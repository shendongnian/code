    var objectA = new ObjectA
    {
    	PropertyA = 6,
    	ObjectB = null
    };
    string serialized = JsonConvert.SerializeObject(objectA, 
                                Newtonsoft.Json.Formatting.Indented, 
                                new JsonSerializerSettings {                                
    								DefaultValueHandling = DefaultValueHandling.Ignore
                                });
