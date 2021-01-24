    [XmlRoot(ElementName = "OUTPUT-HEADER", Namespace = "http://aaa.bbb.ccc/v2")]
    [XmlInclude(typeof(OutputHeaderSubclass))] // Artificial subtype to trigger handling of the `xsi:type` attribute.
    [XmlInclude(typeof(OutputHeader))]
    public class OutputHeader
    {
        [XmlElement(ElementName = "FAULT", Namespace = "")]
        public Fault FaultSection { get; set; }
        [XmlElement(ElementName = "CNL-OUT", Namespace = "")]
        public string ClnOut { get; set; }
    }
    [XmlRoot(ElementName = "OUTPUT-HEADER-SUBCLASS", Namespace = "http://aaa.bbb.ccc/v2")]
    public class OutputHeaderSubclass : OutputHeader
    {
    }
