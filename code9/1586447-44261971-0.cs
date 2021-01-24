    [XmlRoot(ElementName = "variable")]
    public class Variable
    {
        [XmlElement(ElementName = "varName")]
        public string VarName { get; set; }
    
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
    
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    
    }
