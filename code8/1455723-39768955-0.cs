    public class Ticket
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Status status { get; set; }
        public Subject subject { get; set; }
        public User user { get; set; }
    }
    
    public class RootObject
    {
        public List<Ticket> tickets { get; set; }
    }
    public class Status
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    
    public class Subject
    {
        public int id { get; set; }
        public string subject { get; set; }
    }
    
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string company { get; set; }
        public int role_id { get; set; }
        public object created_at { get; set; }
        public string updated_at { get; set; }
    }
    
