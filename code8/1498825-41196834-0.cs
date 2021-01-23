    public class Info
    {
        public string UCode { get; set; }
        public string UName { get; set; }
        public string UPass { get; set; }
    }
    
    public class Response
    {
        public int status { get; set; }
        public string msg { get; set; }
        public Info info { get; set; }
    }
