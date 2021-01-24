    [XmlRoot(ElementName = "CATALOG")]
    public class Catalog
    {
        [XmlElement("CD")]
        public List<Cd> Cds { get; set; }
    }
