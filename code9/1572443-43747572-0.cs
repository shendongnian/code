	public static object DeserializeFromStream(Stream stream)
	{
		var serializer = new JsonSerializer();
		
		using (var sr = new StreamReader(stream))
		using (var jsonTextReader = new JsonTextReader(sr))
		{
			return serializer.Deserialize(jsonTextReader);
		}
	}
