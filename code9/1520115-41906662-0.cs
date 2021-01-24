    public class Event
    {
    	public int eventId { get; set; }
    	public string eventName { get; set; }
    	public List<EventDetails> eventdetail { get; set; }
    	
    	public Event()
    	{
    		eventdetail = new List<EventDetails>();
    	}
    }
