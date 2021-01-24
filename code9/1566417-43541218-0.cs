    public class Transaction
    {
        public ST ST { get; set; }
        public BHT BHT { get; set; }
        [XmlElement]
        public List<HierarchicalLoop> HierarchicalLoop { get; set; } // maybe HierarchicalLoop[]
        [XmlAttribute]
        public string ControlNumber { get; set; } // maybe int
    }
    public class ST
    {
        public string ST01 { get; set; } // maybe int
    }
    public class BHT
    {
        public string BHT01 { get; set; } // maybe int
    }
    public class HierarchicalLoop
    {
        [XmlAttribute]
        public string LoopId { get; set; }
        [XmlAttribute]
        public string LoopName { get; set; }
        [XmlAttribute]
        public string Id { get; set; } // maybe int
        [XmlAttribute]
        public string ParentId { get; set; }
    }
