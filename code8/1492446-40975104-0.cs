    [XmlRoot("DataStructure")]
    public class DataStructurecs
    {
        [XmlElement("message")]
        public List<Message> Message { get; set; }
    }
    public class Message
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlElement("dataBytes")]
        public List<DataBytes> DataBytes { get; set; }
    }
    public class DataBytes
    {
        [XmlAttribute("position")]
        public string Position { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
        [XmlAttribute("typeOfByte")]
        public string TypeOfByte { get; set; }
        [XmlElement("bit")]
        public Bits Bits { get; set; }
        [XmlElement("enum")]
        public List<Enum> Enum { get; set; }
    }
    public class Enum
    {
        [XmlAttribute("val")]
        public string Val { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
    }
    public class Bits
    {
        [XmlAttribute("position")]
        public string Position { get; set; }
        [XmlAttribute("bitval")]
        public string Bitval { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
        [XmlElement("Enum")]
        public List<Enums> BitsEnum { get; set; }
    }
    public class Enums
    {
        [XmlAttribute("val")]
        public string Val { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
    }
