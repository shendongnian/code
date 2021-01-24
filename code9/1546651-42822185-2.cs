    [XmlRoot ("bugs")]
    public class SomeConfiguration
    {
        [XmlElement("bug")]
        public List<string> Bugs { get; set; }
    }
