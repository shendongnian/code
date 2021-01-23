     [XmlRoot(ElementName = "image")]
        public class Image
        {
            [XmlAttribute(AttributeName = "source")]
            public string Source { get; set; }
            [XmlAttribute(AttributeName = "width")]
            public string Width { get; set; }
            [XmlAttribute(AttributeName = "height")]
            public string Height { get; set; }
        }
        [XmlRoot(ElementName = "tileset")]
        public class Tileset
        {
            [XmlElement(ElementName = "image")]
            public Image Image { get; set; }
            [XmlAttribute(AttributeName = "firstgid")]
            public string Firstgid { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "tilewidth")]
            public string Tilewidth { get; set; }
            [XmlAttribute(AttributeName = "tileheight")]
            public string Tileheight { get; set; }
            [XmlAttribute(AttributeName = "tilecount")]
            public string Tilecount { get; set; }
            [XmlAttribute(AttributeName = "columns")]
            public string Columns { get; set; }
        }
