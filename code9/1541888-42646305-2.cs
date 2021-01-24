    [XmlRoot("amount")]
    public sealed class amount
    {
        [XmlElement("currency")]
        public string Description { get; set; }
        // http://stackoverflow.com/a/1528429/613130
        [XmlIgnore]
        public int Value { get; set; }
        [XmlText]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string ValueXml
        {
            get
            {
                return Value.ToString();
            }
            set
            {
                Value = int.Parse(value);
            }
        }
    }
