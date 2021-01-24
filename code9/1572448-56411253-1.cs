    public static class JsonReaderExtensions
    {
    	public static IEnumerable<T> SelectTokensWithRegex<T>(
            this JsonReader jsonReader, Regex regex)
    	{
    		JsonSerializer serializer = new JsonSerializer();
    		while (jsonReader.Read())
    		{
    			if (regex.IsMatch(jsonReader.Path) 
                    && jsonReader.TokenType != JsonToken.PropertyName)
    			{
    				yield return serializer.Deserialize<T>(jsonReader);
    			}
    		}
    	}
    }
