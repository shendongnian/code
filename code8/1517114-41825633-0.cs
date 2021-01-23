    public class Value
    {
    	public ObjectId _id { get; set; }
    	public Event @event { get; set;}
    }
    
    public class Event
    {
    	public string NodeId {get;set;}
    	public string FirmwareVER {get;set;}
    	public double SignalSTR {get;set;}
    	public double battery {get;set;}
    	public double CEL {get;set;}
    	public double WT {get;set;}
    	public string Onlinestat {get;set;}
    	public double timeStamp {get;set;}
    }
