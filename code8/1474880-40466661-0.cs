    public class StreamConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return typeof(Stream).IsAssignableFrom(objectType);
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		return new MemoryStream(Convert.FromBase64String((string)reader.Value));
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		var stream = (Stream)value;
    		using (var sr = new BinaryReader(stream))
    		{
    			var buffer = sr.ReadBytes((int)stream.Length);
    			writer.WriteValue(Convert.ToBase64String(buffer));
    		}
    	}
    }
