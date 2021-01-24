    [XmlInclude(typeof(DerivedT))]
    public class BaseT
    {
        [XmlAttribute("type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
    }
