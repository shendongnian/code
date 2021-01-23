    public class Way
    {
        [XmlAttribute("id", DataType = "long")]
        public long ID { get; set; }
        [XmlElement("nd")]
        public List<NodeReference> References { get; private set; }
        public List<Node> Nodes { get; set; }
        public Way()
        {
            this.References = new List<NodeReference>();
        }
    }
