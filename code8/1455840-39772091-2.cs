    public class UserContacts
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
    public class User : DomainModel
    {
        public List<UserContact> UserContacts { get; set; }
    }
    public class Contact
    {
        public List<UserContact> UserContacts { get; set; }
    }
