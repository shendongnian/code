            XmlSerializer mySerializer = new XmlSerializer(typeof(InvoiceType));
            StreamWriter sw = new StreamWriter(@"C:\New folder\test2.xml");
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            ns.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            mySerializer.Serialize(sw, factura, ns);
            sw.Close();
