    [XmlRoot(ElementName = "doc")]
    public class Doc
    {
        [XmlElement(ElementName = "headline")]
        public Headline Headline { get; set; }
    }
    public class Headline
    {
        [XmlText]
        public string Content { get; set; }
        [XmlElement(ElementName = "hlword")]
        public string HlWord { get; set; }
    }
