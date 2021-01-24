    [XmlRoot(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    public class settings
    {
        [XmlArray("rsids")]
        [XmlArrayItem("rsid")]
        public List<rsid> Rsids { get; set; }
    }
    
    public class rsid
    {
        [XmlAttribute(Form = XmlSchemaForm.Qualified)]
        public string val { get; set; }
    }
