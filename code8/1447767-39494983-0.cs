    public class Names
    {
        [XmlElement("legalName")]
        public LegalName LegalName { get; set; }
    }
    
    public class LegalName
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
       
        [XmlElement("surName")]
        public string SurName { get; set; }
    
        [XmlElement("fullName")]
        public string FullName { get; set; }
    
        [XmlElement("effDate")]
        public string EffDate { get; set; }
        [XmlAttribute("behavior")]
        public string Behavior { get; set; }
    }
