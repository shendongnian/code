    public class Transaction
    {
        [XmlAttribute("ControlNumber")]
        public string ControlNumber { get; set; }
        public ST ST { get; set; }
        public BHT BHT { get; set; }
        [XmlElement("HierarchicalLoop")]
        public List<HierarchicalLoop> HierarchicalLoops { get; set; }
    }
