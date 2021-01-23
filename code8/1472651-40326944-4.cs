    [XmlType("ColorFormat")]
    public class ColorFormat
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string ColorBase { get; set; }
        [XmlIgnore]
        public string Format { get; set; }
        [XmlText]
        public XmlNode[] SerializableFormat
        {
            get
            {
                var doc = new XmlDocument();
                return new XmlNode[] { doc.CreateCDataSection(this.Format) };
            }
            set
            {
                this.Format = value[0].Value;
            }
        }
    }
