    class CustomerAliasXmlEditor : XmlStreamingEditor
    {
		// Confirm that the <customer> element is not in any namespace.
		static readonly XNamespace customerNamespace = ""; 
		
        public static void TransformFromTo(string fromFilePath, XmlReaderSettings readerSettings, string toFilePath, XmlWriterSettings writerSettings)
        {
            using (var xmlReader = XmlReader.Create(fromFilePath, readerSettings))
            using (var xmlWriter = XmlWriter.Create(toFilePath, writerSettings))
            {
                new CustomerAliasXmlEditor(xmlReader, xmlWriter).Process();
            }
        }
        public CustomerAliasXmlEditor(XmlReader reader, XmlWriter writer)
            : base(reader, writer, ShouldTransform, Transform)
        {
        }
        static bool ShouldTransform(XmlReader reader)
        {
            return reader.GetElementName() == customerNamespace + "customer";
        }
        static void Transform(XmlReader from, XmlWriter to)
        {
            var customer = XElement.Load(from);
            var alias = customer.Element(customerNamespace + "alias");
            if (alias != null)
            {
                var name = customer.Element(customerNamespace + "name");
                if (name == null)
                {
                    name = new XElement(customerNamespace + "name");
                    customer.Add(name);
                }
                alias.Remove();
                name.Add(alias);
            }
            customer.WriteTo(to);
        }
    }
