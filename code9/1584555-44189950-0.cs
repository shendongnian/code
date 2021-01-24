    public class Message
    {
    	public int MessageId { get; set; }
    	public int? MessageVal { get; set; }
    	public Payload Payload { get; set; }
    }
    
    public class Payload
    {
    	public int PayloadId { get; set; }
    	public string[] Items { get; set;}
    }
