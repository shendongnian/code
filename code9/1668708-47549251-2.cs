    public class AddressLine
    {
        [XmlText]
        public string Text { get; set; }
        [XmlAttribute("line")]
        public int Line { get; set; }
    }
    public class Address
    {
        [XmlElement("addressline")]
        public List<AddressLine> AddressLines { get; set; }
    }
