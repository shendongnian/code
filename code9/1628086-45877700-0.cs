    public class Entity
    {
        [XmlAttribute]
        public string Type { get; set; }
        [XmlArrayItem("Field")]
        public Field[] Fields { get; set; }
    }
    public class Field
    {
        [XmlAttribute]
        public string Name { get; set; }
        public string Value { get; set; }
    }
