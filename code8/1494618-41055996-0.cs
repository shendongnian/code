    public class MethodLog
    {
        public int count { get; set; }
        public string methodName { get; set; }
        public string lastAccessTimestamp { get; set; }
        public bool firstAccessTimestamp { get; set; }
    }
    
    public class Data
    {
        public string authType { get; set; }
        public string ipAddress { get; set; }
        public List<MethodLog> MethodLog{ get; set; }
        public string requesterGLN { get; set; }
        public string onBehalfOfGLN { get; set; }
        public int totalAccessCount { get; set; }
        public int accessCountPer24Hrs { get; set; }
        public string lastAccessTimestamp { get; set; }
        public string firstAccessTimestamp { get; set; }
        public string firstAccessWithin24hrsTimestamp { get; set; }
    }
    
    public class SingleData
    {
        public Data data { get; set; }
    }
