    public class Conversation
    {
    	public int Id { get; set; }
    	// ...
    	public ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
