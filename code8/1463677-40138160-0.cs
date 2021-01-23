    public class BIDbObject
    {
        // some methods and properties here 
    
        [XmlElement("columns")]
        public BIDbColumns DbColumns { get; set; }
    }
    
    [XmlRoot("root")]
    public class BIDbObjects
    {
        // some methods and properties here 
    
        [XmlArray("dbobjects")]
        [XmlArrayItem("dbobject")]
        public List<BIDbObject> DbObjects { get; set; }
    }
    
    public class BIDbColumn
    {
        // some methods and properties here 
    
        [XmlAttribute("name")]
        public string ColumnName { get; set; }
    }
    
    public class BIDbColumns
    {
        // some methods and properties here 
    
        [XmlElement("column")]
        public List<BIDbColumn> DbColumns { get; set; }
    }
