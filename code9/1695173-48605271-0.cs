    public class Alumno
    {
    	[BsonId]
    	public ObjectId _id { get; set; }
    
    	[BsonElement("name")]
    	public string name { get; set; }
    
    	[BsonElement("age")]
    	public int age { get; set; }
    	
    	public Alumno()
    	{
    		_id = ObjectId.GenerateNewId();
    	}
    }
