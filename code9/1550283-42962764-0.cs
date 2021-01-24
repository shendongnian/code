    public partial class Message
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces XmlFileNamespaces { get; set; }
        /// <summary>
        /// returns a XmlSerializerNamespaces to use when serializing a Message as the root XML object.
        /// If Message was previously deserialized from XML, the actual namespaces observed will be returned.
        /// Otherwise, a default will be returned that suppresses output of the xmlns:xsi and xmlns:xsd namespace attributes.
        /// </summary>
        [XmlIgnore]
        public XmlSerializerNamespaces XmlRootNamespaces
        {
            get
            {
                if (XmlFileNamespaces != null)
                    return XmlFileNamespaces;
                var xmlNamespaces = new XmlSerializerNamespaces();
                xmlNamespaces.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
                // xmlNamespaces.Add("ns", "http://example.com"); // Or, if you prefer, add this namespace as well as disabling xmlns:xsi and xmlns:xsd.
                return xmlNamespaces;
            }
        }
    }
