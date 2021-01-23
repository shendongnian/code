    [XmlRoot("ehd", Namespace = "urn:ehd/001")]
    public class Ehd
    {
        [XmlElement("body")]
        public Body Body { get; set; }
    }
    
    public class Body
    {
        [XmlElement("kostentraeger_liste", Namespace = "urn:ehd/kts/001")]
        public KostentraegerListe KostentraegerListe { get; set; }
    }
    
    public class KostentraegerListe
    {
        [XmlElement("kostentraeger")]
        public List<Kostentraeger> Kostentraeger { get; set; }
    }
    
    public class Kostentraeger
    {
        [XmlAttribute("V")]
        public string Kostentraegernummer { get; set; }
    }
