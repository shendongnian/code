    public class DialogSession
    {
        public int Id { get; set; }
        public virtual DialogUser DialogUser { get; set; }
    }
    
    public class DialogUser
    {
        public int Id { get; set; }
        public virtual ICollection<DialogSession> DialogSessions { get; set; }
    }
    
