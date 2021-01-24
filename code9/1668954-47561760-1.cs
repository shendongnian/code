    [XmlRoot("Persons")]
    public class Persons
    {
        [XmlElement("Person")]
        public List<Person> Persons { get; set; }
    }
    
    public class Person
    {
        [XmlElement("Name")]
        public String Name { get; set; }
    
        [XmlElement("Surname")]
        public String Surname { get; set; }
    
        [XmlElement("City")]
        public String City { get; set; }
    }
