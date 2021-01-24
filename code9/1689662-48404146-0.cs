    [XmlRoot("ColorPages")]
    public class ColorPages
    {
        [XmlElement("Ghost")]
        List<Ghost> ghost{ get; set; }
    
        [XmlElement("Page")]
        List<Page> page{ get; set; }
    }
    [XmlRoot("Ghost")]
    public class Ghost
    {
    
    }
    [XmlRoot("Page")]
    public class Page
    {
    
    }
