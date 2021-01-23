    public class DeviceIndexJsonConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return objectType == typeof(DeviceIndex);
    	}
    
    	public override object ReadJson(JsonReader reader, 
                                        Type objectType, 
                                        object existingValue, 
                                        JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override void WriteJson(JsonWriter writer, 
                                       object value, 
                                       JsonSerializer serializer)
    	{
    		if (value == null) return;
    
    		writer.WriteStartArray();
    
    		var properties = value.GetType().GetProperties();
    		foreach (var property in properties)
    			writer.WriteValue(value.GetType().GetProperty(property.Name).GetValue(value));
    
    		writer.WriteEndArray();
    	}
    }
