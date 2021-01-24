    [XmlRoot("Comprobante", Namespace = "http://cfdi")]
    public class Comprobante : IValidatableObject
    {
        [Required]
        [XmlArray("Conceptos"), XmlArrayItem(typeof(Concepto), ElementName = "Concepto")]
        public List<Concepto> Conceptos { get; set; }
		[XmlAnyElement("Addenda")]
        public XmlElement Addenda { get; set; }
    }
