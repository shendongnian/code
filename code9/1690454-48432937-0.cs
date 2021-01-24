    public static class JsonExtensions
    {
    	public static Dictionary<string, string> ToFlattenDictionary(this JToken token, string path = null)
    	{
    		switch (token.Type)
    		{
    			case JTokenType.Object:
    				return token.Children<JProperty>()
    					.SelectMany(x => x.Value.ToFlattenDictionary(x.Name))
    					.ToDictionary(x => path == null ? x.Key : string.Join(".", path, x.Key), x => x.Value);
    			case JTokenType.Array:
    				return token
    					.SelectMany((x, i) => x.ToFlattenDictionary(i.ToString()))
    					.ToDictionary(x => path == null ? x.Key : string.Join(".", path, x.Key), x => x.Value);
    
    			default:
    				return new Dictionary<string, string>
    				{
    					[path] = (string)((JValue)token).Value
    				};
    		}
    	}
    }
