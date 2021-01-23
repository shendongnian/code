    [XmlRoot("Contacts")]
    public class Contacts : List<Contact>
    {
        
    }
    
    public class Contact
    {
        [XmlAttribute]
        public string Name { get; set; }
    
        [XmlElement("Address")]
        public string StreetAddress { get; set; }
    
        public string AreaCode { get; set; }
    
        public string City { get; set; }
    
        public string Phone { get; set; }
    
        public string Email { get; set; }
    }
