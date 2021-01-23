    [XmlRoot("monster")]
    public class monster
    {
    	[XmlElement(elementName: "flag")]
        public List<flag> flags { get; set; }
    }
