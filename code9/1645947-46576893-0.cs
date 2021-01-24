    [XmlRoot(ElementName = "card")]
        public class Card
        {
            [XmlElement(ElementName = "title")]
            public string Title { get; set; }
            [XmlElement(ElementName = "category")]
            public string Category { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
        }
        [XmlRoot(ElementName = "cards")]
        public class Cards
        {
            [XmlElement(ElementName = "card")]
            public List<Card> Card { get; set; }
        }
        [XmlRoot(ElementName = "data")]
        public class Data
        {
            [XmlElement(ElementName = "cards")]
            public Cards Cards { get; set; }
        }
