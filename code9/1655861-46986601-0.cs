    public class RootObject
    {public string user_id { get; set; }
    	public Dictionary<string, Devices> devices { get; set; }
    }
    public class Devices
    {
    	public List<Session> sessions { get; set; }
    }
    public class Session
    {
    	public List<Connections> connections { get; set; }
    }
    public class Connections
    {
    	public string ip { get; set; }
    	public string user_agent { get; set; }
    	public long last_seen { get; set; }
    }
