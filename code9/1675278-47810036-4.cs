    public class Employee
    {
        [XmlElement(IsNullable = true)]
        public string FirstName { get; set; }
        [XmlElement(IsNullable = true)]
        public string LastName { get; set; }
    }
