    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public List<Event> Events { get; set; }
    }
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public List<User> Users { get; set; }
    }
  
