    [XmlRoot(ElementName = "Address")]
    public class Address
    {
        [XmlElement(ElementName = "Street1")]
        public string Street1 { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "State")]
        public string State { get; set; }
        [XmlElement(ElementName = "Postal")]
        public string Postal { get; set; }
    }
    [XmlRoot(ElementName = "Contact")]
    public class Contact
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
    }
    [XmlRoot(ElementName = "Contacts")]
    public class Contacts
    {
        [XmlElement(ElementName = "Contact")]
        public Contact Contact { get; set; }
    }
    [XmlRoot("GenericRequestData_Type")]
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        [XmlArray("Emails")]
        [XmlArrayItem("Email")]
        public List<string> Emails { get; set; }
        [XmlArray("Issues")]
        [XmlArrayItem("Id")]
        public List<long> IssueIds { get; set; }
    }
