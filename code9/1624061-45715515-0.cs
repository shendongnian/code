        [XmlRoot("Arm")]
        public class Arm 
        {
            [XmlElement("ID")]
            public ID id {get;set;}
            [XmlElement("Dimension")]
            public Dimension dimension { get; set;}
        }
        [XmlRoot("Dimension")]
        public class Dimension
        {
            [XmlAttribute("description")]
            public string Value { get; set; }
            [XmlElement("XMin")]
            public int XMin { get; set; }
            [XmlElement("XMax")]
            public int XMax { get; set; }
            [XmlElement("YMin")]
            public int YMin { get; set; }
            [XmlElement("YMax")]
            public int YMax { get; set; }
        }
        [XmlElement("ID")]
        public class ID
        {
            [XmlAttribute("description")]
            public string Value { get; set; }
            [XmlText]
            public int value { get; set; }
        }
