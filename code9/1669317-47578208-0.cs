    public class Pages
    {
        public int id { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string test { get; set; }
    }
    
    public class Labels
    {
        public string test { get; set; }
        public string test2 { get; set; }
    }
    
    public class RootObject
    {
        public Pages pages { get; set; }
        public Labels labels { get; set; }
    }
