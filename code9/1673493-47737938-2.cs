    public class Example {
        [XmlElement("Node1")]
        public string Node1 { get; set; }
        // define namespace like this, not with a prefix
        [XmlElement("Node2", Namespace = "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner")]
        public string Node2 { get; set; }
    }
