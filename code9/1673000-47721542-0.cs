    [XmlRoot("Comprobante", Namespace = "http://cfdi")]
    public class Comprobante : IValidatableObject
    {
        [Required]
        [XmlArray("Conceptos"), XmlArrayItem(typeof(Concepto), ElementName = "Concepto")]
        public List<Concepto> Conceptos { get; set; }
        public Addenda Addenda { get; set; }
    }
    public class Addenda
    {
        [XmlAnyElement]
        [XmlText]
        public XmlNode[] Nodes { get; set; }
    }
