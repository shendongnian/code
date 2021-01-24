    public class Envelope
    {
        public EnvelopeHeader Header { get; set; }
        public EnvelopeBody Body { get; set; }
    }
    public class EnvelopeHeader
    {
        [XmlElementAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
        public Security Security { get; set; }
    }
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
    [XmlRootAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", IsNullable = false)]
    public class Security
    {
        public SecurityUsernameToken UsernameToken { get; set; }
    }
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
    public  class SecurityUsernameToken
    {
        public string Username { get; set; }
        public SecurityUsernameTokenPassword Password { get; set; }
        [XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
        public string Id { get; set; }
    }
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
    public  class SecurityUsernameTokenPassword
    {
        [XmlAttributeAttribute()]
        public string Type { get; set; }
        [XmlTextAttribute()]
        public string Value { get; set; }
    }
    public  class EnvelopeBody
    {
        public Cat Cat{ get; set; }
    }
