    [XmlRoot("member")]
    public class Member
    {
        [XmlElement("summary")]
        public string Summary { get; set; }
        [XmlIgnore]
        public string Returns { get; set; }
    }
