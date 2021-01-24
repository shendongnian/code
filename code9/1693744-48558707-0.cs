    public class Error
    {
        public int error_code { get; set; }
        public string desc { get; set; }
        public List<string> details { get; set; }
    }
    
    public class ErrorObj
    {
        public string result { get; set; }
        public Error error { get; set; }
    }
