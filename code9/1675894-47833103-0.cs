    [XmlRoot(ElementName = "root", Namespace = "http://foo.bar")]
    public class Root
    {
        // note empty namespace here
        [XmlElement(ElementName = "child", Namespace = "")]
        public Child Child { get; set; }
    }
