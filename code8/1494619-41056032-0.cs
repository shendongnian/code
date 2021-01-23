    void Main()
    {
    	var json = File.ReadAllText(@"C:\pathtojson.json");
    	var result = JsonConvert.DeserializeObject<RootObject>(json);
    	//Generic Linqpad output:
    	result.methodLog.Dump();
    	
    }
    
    public class MethodLog
    {
        public int count { get; set; }
        public string methodName { get; set; }
        public long lastAccessTimestamp { get; set; }
        public long firstAccessTimestamp { get; set; }
    }
    
    public class RootObject
    {
        public string authType { get; set; }
        public string ipAddress { get; set; }
        public List<MethodLog> methodLog { get; set; }
        public string requesterGLN { get; set; }
        public string onBehalfOfGLN { get; set; }
        public int totalAccessCount { get; set; }
        public int accessCountPer24Hrs { get; set; }
        public long lastAccessTimestamp { get; set; }
        public long firstAccessTimestamp { get; set; }
        public long firstAccessWithin24hrsTimestamp { get; set; }
    }
