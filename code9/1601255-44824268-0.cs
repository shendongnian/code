    public class SampleModel
    {
        [XmlElement("FIELD")]
        public List<Field> Fields { get; set; }
    }
    
    public class Field
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    }
