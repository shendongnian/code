    public class ProhibitArraysConverter<T> : JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, 
            JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, 
            object existingValue, JsonSerializer serializer)
    	{
    		var jsonObject = JToken.Load(reader);
    		if (ContainsArray(jsonObject))
    			return null;
    
    		T target = (T)Activator.CreateInstance(objectType);
    		serializer.Populate(jsonObject.CreateReader(), target);
    		return target;
    	}
    
    	public override bool CanConvert(Type objectType)
    	{
    		return objectType == typeof(T);
    	}
    
    	private static bool ContainsArray(JToken containerToken)
    	{
    		if (containerToken.Type == JTokenType.Object)
    		{
    			foreach (JProperty child in containerToken.Children<JProperty>())
    			{
    				if (child.Type == JTokenType.Array || 
                        child.Value.Type == JTokenType.Array)
    				{
    					return true;
    				}
    				ContainsArray(child.Value);
    			}
    		}
    		else if (containerToken.Type == JTokenType.Array)
    		{
    			return true;
    		}
    		
    		return false;
    	}
    }
