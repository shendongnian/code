    public class ContactInformation
    {
        [XmlElement(ElementName = "Contact")]
        public string Contact { get; set; }
        [XmlElement(ElementName = "EmailAddress")]
        public string EmailAddress { get; set; }
        [XmlElement(ElementName = "TelephoneNumber")]
        public string TelephoneNumber { get; set; }
        [XmlElement(ElementName = "ContactTypeIdentifier")]
        public string ContactTypeIdentifier { get; set; }
    }
    public class Identifier
    {
        [XmlAttribute("Authority")]
        public string Authority { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
    public class Sender
    {
        [XmlElement(ElementName = "Identifier")]
        public Identifier Identifier { get; set; }
        [XmlElement(ElementName = "ContactInformation")]
        public ContactInformation ContactInformation { get; set; }
    }
    public class StandartBusinessDocumentHeader
    {
        [XmlElement(ElementName = "HeaderVersion")]
        public string HeaderVersion { get; set; }
        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }
    }
    [XmlRoot(ElementName = "inventoryReportMessage", Namespace = "urn:gs1:ecom:inventory_report:xsd:3")]
    public class InventoryReportMessage
    {
        [XmlElement("StandardBusinessDocumentHeader", Namespace = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader")]
        public StandartBusinessDocumentHeader Header { get; set; }
    }
