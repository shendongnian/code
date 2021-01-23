    [XmlType("image", Namespace = "http://flibble")]
    public class Image
    {
        [XmlElement(ElementName = "loc")]
        public string UrlLocation { get; set; }
        [XmlElement(ElementName = "caption")]        
        public string Caption { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        
    }  
