    [BsonIgnoreExtraElements]
    public class User : Document
    {
    	[BsonDefaultValue(null)]
    	[BsonSerializer(typeof(FixingReferralsSerializer))]
    	public List<ObjectId?> referrals { get; set; }
    }
