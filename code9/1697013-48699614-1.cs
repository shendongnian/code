    internal class MyCustomDateTimeSerializer<TDateTime> : IBsonSerializer
    {
    	static MyCustomDateTimeSerializer()
    	{
    		if (typeof(TDateTime) != typeof(DateTime) && typeof(TDateTime) != typeof(DateTime?))
    		{
    			throw new InvalidOperationException($"MyCustomDateTimeSerializer could be used only with {nameof(DateTime)} or {nameof(Nullable<DateTime>)}");
    		}
    	}
    	
    	public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    	{
    		// Deserialization logic
    	}
    
    	public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
    	{
    		// Serialization logic
    	}
    
    	public Type ValueType => typeof(TDateTime);
    }
    
    public class SomeDocument
    {
    	// ...
    
    	[BsonSerializer(typeof(MyCustomDateTimeSerializer<DateTime>))]
    	public DateTime Date1 { get; set; }
    
    	[BsonSerializer(typeof(MyCustomDateTimeSerializer<DateTime?>))]
    	public DateTime? Date2 { get; set; }
    }
