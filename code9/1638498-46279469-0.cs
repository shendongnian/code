    public class RARAGA
    {
        public List<string> a { get; set; }
        public List<string> b { get; set; }
        public List<string> c { get; set; }
        public List<string> v { get; set; }
        public List<string> p { get; set; }
        public List<int> t { get; set; }
        public List<string> l { get; set; }
        public List<string> h { get; set; }
        public string o { get; set; }
    }
    
    public class Result
    {
        public RARAGA RARAGA { get; set; }
    }
    
    public class RootObject
    {
        public List<object> error { get; set; }
        public Result result { get; set; }
    }
