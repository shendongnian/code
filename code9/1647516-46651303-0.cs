    public class MyElement
    {
        [XmlAttribute]
        public string PropertyX { get; set; }
        [XmlElement]
        public MySubElement SubElement { get; set; }
        [DefaultValue("")]
        public string ElementXml { get; set; }
    }
