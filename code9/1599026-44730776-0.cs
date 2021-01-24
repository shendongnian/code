    [XmlRoot(ElementName = "column")]
        public class Column
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlText]
            public string Text { get; set; }
        }
    
        [XmlRoot(ElementName = "row")]
        public class Row
        {
            [XmlElement(ElementName = "column")]
            public List<Column> Column { get; set; }
        }
    
        [XmlRoot(ElementName = "rows")]
        public class Rows
        {
            [XmlElement(ElementName = "row")]
            public List<Row> Row { get; set; }
        }
    
        [XmlRoot(ElementName = "result")]
        public class Result
        {
            [XmlElement(ElementName = "rows")]
            public Rows Rows { get; set; }
        }
    
        [XmlRoot(ElementName = "response")]
        public class Response
        {
            [XmlElement(ElementName = "result")]
            public Result Result { get; set; }
            [XmlAttribute(AttributeName = "uri")]
            public string Uri { get; set; }
            [XmlAttribute(AttributeName = "action")]
            public string Action { get; set; }
        }
