    public class ProductionOrderFile
    {
        public string ProductionOrderName { get; set; }
        public string ProductCode { get; set; }
        [System.Xml.Serialization.XmlElement]
        public List<Batch> Batches { get; set; }
        [System.Xml.Serialization.XmlElement]
        public List<AggregationLevelConfiguration> Levels { get; set; }
        [System.Xml.Serialization.XmlElement]
        public List<VariableData> VariableData { get; set; }
    }
