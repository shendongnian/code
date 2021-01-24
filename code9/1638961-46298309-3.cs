    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
    }
    
    public class Speciality
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    
    public class Success
    {
        public User User { get; set; }
        public Speciality Speciality { get; set; }
    }
    
    public class Status
    {
        public List<Success> success { get; set; }
    }
    
    public class RootObject
    {
        public Status status { get; set; }
    }
