    public class Data {
        public List<int> failed { get; set; }
        public List<int> completed { get; set; }
    }
    
    public class RootObject {
        public List<string> name { get; set; }
        public Data data { get; set; }
    }
