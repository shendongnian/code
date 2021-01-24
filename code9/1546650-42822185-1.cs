    [XmlRoot ("someConfiguration")]
    public class SomeConfiguration
    {
        [XmlArray("bugs")]
        [XmlArrayItem("bug")]
        public List<string> Bugs { get; set; }
    }
