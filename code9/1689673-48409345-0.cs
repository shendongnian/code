    public class UserInfo
    {
    	[BsonId]
    	public ObjectId Id { get; set; }
    	public List<KeyValuePair<string, string>> Metadata { get; set; }
    }
