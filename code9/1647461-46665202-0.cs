    [XmlRoot(ElementName = "rootentity")]
    public class Rootentity
    {
        [XmlElement(ElementName = "cascadingentities")]
        public List<CascadingEntity> Cascadingentities { get; set; } 
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
