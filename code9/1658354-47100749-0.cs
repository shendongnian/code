    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public string wka { get; set; }
    }
        
    public class JsonContent
    {
        public bool error { get; set; }
        public User user { get; set; }
    }
