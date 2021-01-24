    public class Session
    {
        public string SessionDate { get; set; }
    }
    public class Status
    {
        public string Description { get; set; }
        public int Code { get; set; }
    }
    public class EventAppGetAllSessionByCustomerIdResult
    {
        public KeyValuePair<string, Session[]>[] EventAppGetAllSessionByCustomerId { get; set; }
    
        public Status Status { get; set; }
    }
