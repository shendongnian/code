        [XmlRoot(ElementName = "dato")]
        public class Dato
        {
            [XmlAttribute(AttributeName = "nome")]
            public string Nome { get; set; }
            [XmlText]
            public string Text { get; set; }
        }
        [XmlRoot(ElementName = "record")]
        public class Record
        {
            [XmlElement(ElementName = "dato")]
            public List<Dato> Dato { get; set; }
        }
        [XmlRoot(ElementName = "allegati")]
        public class Allegati
        {
            [XmlElement(ElementName = "record")]
            public List<Record> Record { get; set; }
            [XmlAttribute(AttributeName = "tot_ele")]
            public string Tot_ele { get; set; }
        } 
