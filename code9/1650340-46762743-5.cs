    public class AddressBook
    {
        public AddressBook()
        {
            Contacts = new List<Contact>();
        }
    
        public List<Contact> Contacts { get; set; }
    }
    
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
    }
