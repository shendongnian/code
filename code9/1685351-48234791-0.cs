    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class root
    {
        public string b { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("level2", IsNullable = true)]
        public rootLevel2[] level1 { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootLevel2
    {
        public string id { get; set; }
    
        [System.Xml.Serialization.XmlArrayItemAttribute("level4", IsNullable = true)]
        public string[] level3 { get; set; }
    }
