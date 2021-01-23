    public class CodelistFilters
    {    
        [XmlElement("Group")]
        public List<Group> Groups { get; set; }
    }
    
    public class Group
    {
        [XmlAttribute]
        public string Relationship { get; set; }
    
        [XmlElement("Group")]
        public List<Group> Groups { get; set; }
    
        [XmlElement("CodelistFilter")]
        public List<CodelistFilter> CodelistFilters { get; set; }
    }
    
    public class CodelistFilter
    {
        [XmlAttribute]
        public string Name { get; set; }
    
        [XmlAttribute]
        public string Value1 { get; set; }
    
        [XmlAttribute]
        public string Value2 { get; set; }
    }
