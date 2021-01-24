    public class Conversation
    {
    	public int Id { get; set; }
    	// ...
    }
    public class ServiceRequest
    {
    	// ...
    	public Conversation Conversation { get; set; }
    }
