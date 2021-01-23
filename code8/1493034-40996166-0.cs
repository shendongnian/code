    public class Items
    {
        [XmlElement("Text")]
        public string Text { get; set; }
        [XmlElement("Url")]
        public string Url { get; set; }
        [XmlElement("Description")]
        public string Description { get; set; }
        [XmlElement("Image")]
        public Image Image { get; set; }
    }
    public class Image
    {
        [XmlAttribute("source")]
        public string source { get; set; }
    }
