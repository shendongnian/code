    public class Value
    {
        public string First { get; set; }
        public string Second { get; set; }
    }
    
    public class RootObject
    {
        public string Key { get; set; }
        public List<Value> Values { get; set; }
    }
