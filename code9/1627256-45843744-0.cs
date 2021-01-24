        // Create a Serializer with specific tweaked settings, like assigning a specific ContractResolver
    
        var newtonSoftJsonSerializerSettings = new JsonSerializerSettings
		{
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore, // Ignore the Self Reference looping
			PreserveReferencesHandling = PreserveReferencesHandling.None, // Do not Preserve the Reference Handling
			ContractResolver = new CamelCasePropertyNamesContractResolver(), // Make All properties Camel Case
			Formatting = Newtonsoft.Json.Formatting.Indented
		};
    // To the final serialization call add the formatter as shown underneath
    
    var result = JsonConvert.SerializeObject(obj,newtonSoftJsonSerializerSettings.Formatting);
