    public class UrlEncodingConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return objectType == typeof(string);
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		if (value == null) return;
    		var encodedValue = System.Web.HttpUtility.UrlEncode((string)value);
    		writer.WriteValue(encodedValue);
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		if (reader.Value == null) return null;
    		var decodedValue = System.Web.HttpUtility.UrlDecode(reader.Value.ToString());
    		return decodedValue;
    	}
    }
