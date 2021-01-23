    [XmlRoot(ElementName = "interlocking")]
    public class Interlocking
    {
        [XmlElement(ElementName = "signals")]
        public List<Signals> Signals { get; set; }
        [XmlElement(ElementName = "routes")]
        public List<Routes> Routes { get; set; }
    
        //[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        //public string Xsi { get; set; }
        //[XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        //public string Xsd { get; set; }
    
        [XmlIgnore]
        public IList Children
        {
            get
            {
                return new CompositeCollection()
                {
                    new CollectionContainer() { Collection = Signals },
                    new CollectionContainer() { Collection = Routes }
                };
            }
        }
    }
