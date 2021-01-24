    public class User
    {
       
        public int UserID { get; set; }
        public List<Event> Events { set; get; }
    }
    public class Event
    {
       
        public int EventID { get; set; }
        public List<User> Users { set; get; }
    }
