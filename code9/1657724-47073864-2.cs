    [XmlRoot("MFAB.ini")]
    public class MfabWithParents {
        [XmlElement("PARENT")]
        public ParentSection[] Parents { get; set; }
    }
    public class ParentSection {
		[XmlAttribute("name")]
		public string Name { get; set; }
		[XmlElement("SECTION")]
        public Section[] Sections { get; set; }
    }
