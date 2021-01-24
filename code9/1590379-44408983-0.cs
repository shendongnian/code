    public class Dimension
    {
        public string name { get; set; }
        public int elements { get; set; }
        public string comment { get; set; }
    }
    
    public class MyObject
    {
        public string name { get; set; }
        public int section { get; set; }
        public string comment { get; set; }
        public List<Dimension> dimensions { get; set; }
    }
