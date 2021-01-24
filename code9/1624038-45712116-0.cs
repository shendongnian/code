    [Serializable]
    public class Person
    {
        [XmlAttribute]
        public string Email { get; set; }
        public string Loaded { get; set; }
        public string LoadError{ get; set; }
    }
    
    Person p = new Person
    {
        Email = "abc",
        Loaded = "abc";
        LoadError = "abc"
    };
    new XmlSerializer(typeof(Person)).Serialize(Console.Out, Person);
