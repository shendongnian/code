    public class UserDetails
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        // other properties ...
        public string UserID { get; set; }
        public User User { get; set; } // the problematic navigation property
    }
