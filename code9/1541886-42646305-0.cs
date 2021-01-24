    [XmlRoot("amount")]
    public sealed class amount
    {
        [XmlElement("currency")]
        public string Description { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
