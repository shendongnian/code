    public class Coordinate
    {
        public string type { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }
    
    public class From
    {
        public string id { get; set; }
        public string name { get; set; }
        public int score { get; set; }
        public Coordinate coordinate { get; set; }
        public object distance { get; set; }
    }
    
    public class Coordinate2
    {
        public string type { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }
    
    public class To
    {
        public string id { get; set; }
        public string name { get; set; }
        public object score { get; set; }
        public Coordinate2 coordinate { get; set; }
        public object distance { get; set; }
    }
    
    public class Stations
    {
        public List<From> from { get; set; }
        public List<To> to { get; set; }
    }
    
    public class RootObject
    {
        public Stations stations { get; set; }
    }
