    public class UserContacts
    {
        public int UserId { get; set; } 
        public virtual User User { get; set; }
        public int ContactId { get; set; } // In lack of better name.
        public virtual User Contact { get; set; }
    }
    public class User : DomainModel
    {
        public List<UserContacts> Contacts { get; set; }
    }
