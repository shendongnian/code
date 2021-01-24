    public class Component
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public int inboundQueueSize { get; set; }
        public int outboundQueueSize { get; set; }
    }
    
    public class Folder
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<Folder> childFolders { get; set; }
        public IList<Component> childComponents { get; set; }
    }
    
    public class Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<Folder> childFolders { get; set; }
        public IList<Component> childComponents { get; set; }
    }
    
    public class Root
    {
        public Data data { get; set; }
        public object error { get; set; }
    }
