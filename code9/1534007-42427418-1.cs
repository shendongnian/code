    public class Employee : BaseEntity<int>
    {
        public string OfficeBureau { get; set; }
        public string Supervisor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
    
        // TODO:
        // public virtual ICollection<Case> Cases { get; set; }
    }
