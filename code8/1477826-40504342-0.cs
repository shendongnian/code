        [XmlRoot("items")]
        public class Items
        {
            [XmlElement("item")]
            public Item[] Item { get; set; }
        }
        [XmlRoot("item")]
        public class Item
        {
            [XmlElement("name")]
            public string Name { get; set; }
        }
