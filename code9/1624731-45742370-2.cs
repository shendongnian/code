    public class History
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public int minAgo { get; set; }
    }
    
    public class RootObject
    {
        public string group { get; set; }
        public string tracker { get; set; }
        public string measureTime { get; set; }
        public int minAgo { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public List<History> history { get; set; }
    }
