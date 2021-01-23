    [XmlRoot("People")]
    public class People : List<Person>
    {
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
