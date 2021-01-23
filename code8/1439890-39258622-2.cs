    public class Server
    {
        public string Name {get;set;}
        public int CpuUsage {get;set;}
        public int RamUsage {get;set;}
    }
    public class HandlebarsJson
    {
        public int Threshold {get;set;}
        public List<Server> ListOfServers {get;set;}
    }
