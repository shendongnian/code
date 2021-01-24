    public class FixingReferralsSerializer : EnumerableSerializerBase<List<ObjectId?>>
    {
    	public override List<ObjectId?> Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    	{
    		if (context.Reader.CurrentBsonType == BsonType.String)
    		{
    			context.Reader.ReadString();
    			return null;
    		}
    
    		return base.Deserialize(context, args);
    	}
    
    	protected override void AddItem(object accumulator, object item)
    	{
    		((List<ObjectId?>)accumulator).Add((ObjectId?)item);
    	}
    
    	protected override object CreateAccumulator()
    	{
    		return new List<ObjectId?>();
    	}
    
    	protected override IEnumerable EnumerateItemsInSerializationOrder(List<ObjectId?> value)
    	{
    		return value;
    	}
    
    	protected override List<ObjectId?> FinalizeResult(object accumulator)
    	{
    		return (List<ObjectId?>)accumulator;
    	}
    }
