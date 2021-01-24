    public class UserData
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    
    public class User
    {
        public List<UserData> userData { get; set; }
        public string MainId { get; set; }
        public string MainDept { get; set; }
    }
    
    public class RootObject
    {
        public List<User> Users { get; set; }
    }
