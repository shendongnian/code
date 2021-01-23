    public class General
    {
        public string key { get; set; }
        public List<string> value { get; set; }
    }
    
    public class RootObject
    {
        public List<General> General { get; set; }
    }
