    public class Program
    {
    	public static void Main()
    	{
    		string json = @"{
    						  ""user_id"": ""something_name"",
    						  ""devices"": {
    							"""": {
    							  ""sessions"": [
    								{
    								  ""connections"": [
    									{
    									  ""ip"": ""225.225.225.225"",
    									  ""user_agent"": ""something"",
    									  ""last_seen"": 1504266816737
    									}
    								  ]
    								}
    							  ]
    							}
    						  }
    						}";
    
    		Console.WriteLine("Deserializing json...");
    
    		//dynamic values = JsonConvert.DeserializeObject<dynamic>(json);
    	    //var ip = values.devices[""].sessions[0].connections[0].ip;
    
    	    RootObject o = JsonConvert.DeserializeObject<RootObject>(json, new JsonSerializerSettings
    		{
    			MissingMemberHandling = MissingMemberHandling.Ignore, 
    			NullValueHandling = NullValueHandling.Ignore //these settings are not important here
    		});
    		Console.WriteLine("Success!");
    		foreach (var dev in o.devices)
    		{
    			Console.WriteLine("  Device Key   #: {0}", dev.Key);
    			Console.WriteLine("  Device Value #: {0}", dev.Value);
    			Console.WriteLine("            IP #: {0}", dev.Value.sessions[0].connections[0].ip);
    		}
    	}
    }
    
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
