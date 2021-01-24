    string unknownJson = "{\r\n  \"Id\": \"1e4495d3-4cd1-4bf2-9da6-4acee2f7a70e\",\r\n  \"Customers\": [\r\n    \"Alice\",\r\n    \"Bob\",\r\n    \"Eva\"\r\n  ]\r\n}";
    
        JsonSerializer serializer = new JsonSerializer();
        dynamic deserializedObject;
        
        using (var stringReader = new StringReader(unknownJson))
        {
            using (var jsonReader = new JsonTextReader(stringReader))
        	{
        	    deserializedObject = serializer.Deserialize(jsonReader);
            }
        }
