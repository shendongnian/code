    public class AllContacts
    {
        public string code { get; set; }
        public string message { get; set; }
        public ContactList contacts { get; set; }
    }
    public class ContactList
    {
        public string contactId { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string number { get; set; }
    }
