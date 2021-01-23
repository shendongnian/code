    public class TestingObjectTypeSerializer : IBsonSerializer
    {
    	public Type ValueType { get; } = typeof(string);
    
    	public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    	{
    		if (context.Reader.CurrentBsonType == BsonType.Int32) return GetNumberValue(context);
    
    		return context.Reader.ReadString();
    	}
    
    	public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
    	{
    		context.Writer.WriteString(value as string);
    	}
    
    	private static object GetNumberValue(BsonDeserializationContext context)
    	{
    		var value = context.Reader.ReadInt32();
    
    		switch (value)
    		{
    			case 1:
    				return "one";
    			case 2:
    				return "two";
    			case 3:
    				return "three";
    			default:
    				return "BadType";
    		}
    	}
    }
