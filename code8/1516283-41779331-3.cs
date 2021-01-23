    public static T DeserializeObject<T>(string jsonObj)
    {
    	return JsonConvert.DeserializeObject<T>(jsonObj,
    		new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, Formatting = Formatting.Indented });
    }
