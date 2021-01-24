    [Serializable]
    public class ItemAttributes
    {
        public string Binding { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        [XmlElement(ElementName = "Feature")]
        public string[] Feature { get; set; }
    }
