        public class Data
    {
        public string username { get; set; }
        public string password { get; set; }
        public string LoginToken { get; set; }
    }
    
    public class RootObject
    {
        public Data data { get; set; }
    }
