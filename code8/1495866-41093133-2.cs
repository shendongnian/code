    public class DialogSession
    {
        public int DialogSessionId { get; set; }
        public virtual DialogUser DialogUser { get; set; }
    }
    
    public class DialogUser
    {
        public int DialogUserId { get; set; }
        public virtual ICollection<DialogSession> DialogSessions { get; set; }
    }
    
