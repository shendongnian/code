     [XmlRoot(ElementName = "myitem")]
        public class Myitem
        {
            [XmlElement(ElementName = "Item1")]
            public string Item1 { get; set; }
            [XmlElement(ElementName = "Item2")]
            public string Item2 { get; set; }
            [XmlElement(ElementName = "Item3")]
            public string Item3 { get; set; }
        }
    
        [XmlRoot(ElementName = "root")]
        public class Root
        {
            [XmlElement(ElementName = "myitem")]
            public List<Myitem> Myitem { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
        }
