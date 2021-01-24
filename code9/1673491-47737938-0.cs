    public class Example {
        [XmlElement("Node1")]
        public string Node1 { get; set; }
        // define namespace like this, not with a prefix
        // obviously replace "mynamespace" with real namespace you need
        [XmlElement("Node2", Namespace = "mynamespace")]
        public string Node2 { get; set; }
    }
