    [XmlRoot("root")]
    public class BIObjects
    {
        public BIObject() 
        {
            Items = new List<BIObject>();
        }
        [XmlArray("objects")]
        [XmlArrayItem("object")]
        public List<BIObject> Objects { get; set; }
    }
 
    public class BIObject
    {
        [XmlAttribute("database")]
        public string Database { get; set; }
        [XmlAttribute("schema")]
        public string Schema { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("type")]
        public string ObjectType { get; set; }
    }
