    [XmlRoot("MFAB.ini")]
    public class Mfab {
        [XmlElement("SECTION")]
        public Section[] Sections { get; set; }
    }
    public class Section {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("Piece")]
        [XmlText]
        public string Piece { get; set; }
    }
