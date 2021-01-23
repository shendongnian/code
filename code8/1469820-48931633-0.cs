    // Construct a JObject.
    var jObject = JObject.Parse("{ SomeName: \"Some value\" }");
    
    // Deserialize the object into an ExpandoObject (don't use object, because you will get a JObject).
    var payload = JsonConvert.DeserializeObject<ExpandoObject>(jObject.ToString());
    
    // Now you can serialize the object using any serializer settings you like.
    var json = JsonConvert.SerializeObject(payload, new JsonSerializerSettings
    {
    	ContractResolver = new DefaultContractResolver
    	{
    		NamingStrategy = new CamelCaseNamingStrategy
    		{
    			// Important! Make sure to set this to true, since an ExpandoObject is like a dictionary.
    			ProcessDictionaryKeys = true,
    		}
    	}
    }
    );
    
    Console.WriteLine(json); // Outputs: {"someName":"Some value"}
