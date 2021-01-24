    public class Parameter
    {
        [XmlElement("action")]
        public int Action { get; set; }
        [XmlElement("item")]
        public int Item { get; set; }
    }
    [XmlRoot("Batch")]
    public class Batch
    {
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("fileField")]
        public string FileField { get; set; }
        [XmlElement("output")]
        public string Output { get; set; }
        [XmlElement("input")]
        public List<string> Inputs { get; set; }
        [XmlElement("parameters")]
        public List<Parameter> Parameters { get; set; }
    }
