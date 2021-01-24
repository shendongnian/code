    [XmlRoot("treffer")]
    public class DeAnalyseArtikelXmlDto
    {
        [XmlElement("prod_internid")]
        public long ArtikelId { get; set; }
    
        [XmlElement("md_nr")]
        public int MedienNr { get; set; }
        [XmlElement("md_mart_bez")]
        public DeMedienArtXmlDto MedienArt { get; set; }    
    }
