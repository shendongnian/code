    public class Document
    {
        public Document() { }
        [XmlElement("ID")]
        public int ID { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Company", Type = typeof(CompanySurrogate))]
        public Company Comp { get; set; }
    }
