    public class User
    {
        public User()
        {
            EventsOrganized = new HashSet<Event>();
            EventsSubscribedFor = new HashSet<Event>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Event> EventsOrganized { get; set; }
        public virtual ICollection<Event> EventsSubscribedFor { get; set; }
    }
    public class Event
    {
        public Event()
        {
            Participants = new HashSet<User>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganizerId { get; set; }
        public virtual User Organizer { get; set; }
        public ICollection<User> Participants { get; set; } 
    }
