    public class Fields
    {
        public string key1 { get; set; }
        public string key2 { get; set; }
    }
    public class RootObject
    {
        public long creationTimestamp { get; set; }
        public long lastUpdatedTimestamp { get; set; }
        public long lastStageChangeTimestamp { get; set; }
        public Fields fields { get; set; }
    }
