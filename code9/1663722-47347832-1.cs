    [XmlRoot(ElementName = "Members", Namespace = "")]
    public class Members
    {
        [XmlElement("Member")]
        public Member[] member { get; set; }
    }
    
    public class Member
    {
        [XmlElementAttribute("Name")]
        public string Name { get; set; }
    
        [XmlElementAttribute("Status")]
        public string Status { get; set; }
    }
