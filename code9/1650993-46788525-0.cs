    public class FieldList
    {
        [XmlArray("fields")]
        [XmlArrayItem("field")]
        public List<Field> Fields { get; set; }
    }
