    var objectB = new ObjectB
    {
    	PropertyA = 2 //The default value is also 2.
    };
    string serialized = JsonConvert.SerializeObject(objectB, 
                                Newtonsoft.Json.Formatting.Indented, 
                                new JsonSerializerSettings {                                
    								DefaultValueHandling = DefaultValueHandling.Ignore
                                });
