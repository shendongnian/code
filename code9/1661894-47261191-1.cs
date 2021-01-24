    [XmlRoot(ElementName = "root", Namespace = "")]
    public class Note
    {
        [XmlElementAttribute("To")]
        public string To { get; set; }
        [XmlElementAttribute("From")]
        public string From { get; set; }
        [XmlElementAttribute("Heading")]
        public string Heading { get; set; }
        [XmlElementAttribute("Body")]
        public string Body { get; set; }
    }
