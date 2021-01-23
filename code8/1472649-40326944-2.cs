    [XmlType("ColorFormat")]
    public class ColorFormat
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string ColorBase { get; set; }
        [XmlIgnore]
        public string Format { get; set; }
        [XmlAnyElement]
        public XmlCDataSection SerializableFormat
        {
            get
            {
                var doc = new XmlDocument();
                return doc.CreateCDataSection(this.Format);
            }
            set
            {
                this.Format = value.Value;
            }
        }
    }
