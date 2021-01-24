    public partial class RCMR_IN000030UV01
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlsn
        {
            get
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("x", "urn:bccdx.ca");
                return ns;
            }
            set
            {
                // Do nothing - fake property.
            }
        }
    }
