    public class ClsTest
    {
        [XmlElement("name")]
        public string Name { get; set; }
    
        [XmlArray("values")]
        [XmlArrayItem("value")]
        public IndexedFloat[] Values { get; set; }
    }
    
    public class IndexedFloat
    {
        [XmlAttribute("index")]
        public int Index { get; set; }
    
        [XmlText]
        public float Value { get; set; }
    }
