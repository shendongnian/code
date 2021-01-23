    public class ThreeDSecure
    {
        [XmlElement("status")]
        public string Status { get; set; }
        [XmlElement("eci")]
        public string Eci { get; set; }
        [XmlElement("cavv")]
        public string Cavv { get; set; }
        [XmlElement("xid")]
        public string Xid { get; set; }
        [XmlElement("algorithm")]
        public string Algorithm { get; set; }
    }
