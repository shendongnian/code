    public class A
    {
    	[JsonProperty("custom")]
    	public KeyValuePair<string, string> Custom
    	{
    		get;
    		set;
    	}
    }
    
    class KeyValueStringPairConverter : JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		KeyValuePair<string, string> item = (KeyValuePair<string, string>)value;
    		writer.WriteStartObject();
    		writer.WritePropertyName(item.Key);
    		writer.WriteValue(item.Value);
    		writer.WriteEndObject();
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override bool CanConvert(Type objectType)
    	{
    		return objectType == typeof (KeyValuePair<string, string>);
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		A custom = new A();
    		JsonSerializerSettings settings = new JsonSerializerSettings{Converters = new[]{new KeyValueStringPairConverter()}};
    		custom.Custom = new KeyValuePair<string, string>("destination", "foo");
    		Console.WriteLine(JsonConvert.SerializeObject(custom, settings));
    	}
    }
