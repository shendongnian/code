    public class User
    {
        //public string __invalid_name__$id { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public string DateJoined { get; set; }
        public string Picture { get; set; }
        public string AccessToken { get; set; }
    }
    
    public class RootObject
    {
        //public string __invalid_name__$id { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public User user { get; set; }
    }
