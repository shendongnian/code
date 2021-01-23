    [MessageContract]
    public class Messanger
    {
        [MessageBodyMember]
        [XmlElement(ElementName = "NumbersList")]
        public NumbersList NumbersList;
    }
    
    [DataContract]
    [XmlRoot(ElementName = "NumbersList")]
    public class NumbersList
    {
        [XmlElement(ElementName = "Count")]
        public int Count { get; set; }
    
        [XmlElement(ElementName = "Number")]
        public List<int> Number { get; set; }
    }
