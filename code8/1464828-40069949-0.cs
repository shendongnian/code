    public class Result
    {
        public string url { get; set; }
        public string name { get; set; }
    }
    
    public class Pokemon
    {
        public int count { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
