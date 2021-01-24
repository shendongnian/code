    [XmlType("tests")]
    public class Tests
    {
        [XmlArray("tests")]
        public List<Test> Tests { get; set; }
    }
    [XmlType("test")]
    public class Test
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("age")]
        public int Age { get; set; }
        [XmlElement("informations")]
        public string Info { get; set; }
    }
    var serializer = new XmlSerializer(typeof(Tests));
    Tests tests = null;
    using (var reader = new StreamReader(pathToXmlFile))
    {
        tests = (Tests)serializer.Deserialize(reader);
    }
    // use tests for your needs
    foreach(var test in tests.Tests)
    {
        // test.Id
    }
