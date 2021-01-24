    public class ConfigurationRequest
    {
        public int RequestId { get; set; }
        public int RequestNumber { get; set; }
        public string ReqDesc { get; set; }
        // EF will pair the below FK to nav by convention. You could also use ForeignKey attribute.
        public int RequestingUserId { get; set; }
        public User RequestingUser { get; set; }
        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string UserRole {get; set; }
        public string UserName {get; set; }
        // you need a collection for each relationship. InverseProperty tells EF how to match them to User FK
        [InverseProperty("RequestingUser")]    
        public virtual ICollection<ConfigurationRequest> RequestsRaised { get; set; }
        [InverseProperty("AssignedUser")]    
        public virtual ICollection<ConfigurationRequest> RequestsAssigned { get; set; }
    }
