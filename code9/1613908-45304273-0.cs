    public class Result
    {
        public string name { get; set; }
        public string address { get; set; }
    }
    
    public class Error
    {
        public string message { get; set; }
    }
    
    public class Success
    {
        public string message { get; set; }
    }
    
    public class RootObject
    {
        public List<Result> result { get; set; }
        public List<Error> error { get; set; }
        public List<Success> success { get; set; }
    }
