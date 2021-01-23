    public class User
    {
        public string userID { get; set; }
        public string pass { get; set; }
        public bool banned { get; set; }
        public bool online { get; set; }
        public IPAddress lastIp { get; set; }
        public bool admin { get; set; }
        public Job currentJob { get; set; }
    }
