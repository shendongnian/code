    public class FixingReferralsSerializer : ArraySerializer<ObjectId?>
    {
    	public override ObjectId?[] Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    	{
    		if (context.Reader.CurrentBsonType == BsonType.String)
    		{
    			context.Reader.ReadString();
    			return null;
    		}
    
    		return base.Deserialize(context, args);
    	}
    }
