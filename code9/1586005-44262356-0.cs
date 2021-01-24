                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlSerializer xmlserializer = new XmlSerializer(typeof(Value));
                StringWriter stringWriter = new StringWriter();
                XmlWriter writer2 = XmlWriter.Create(stringWriter, new XmlWriterSettings {
                    OmitXmlDeclaration = true,
                    ConformanceLevel = ConformanceLevel.Fragment
                });
                writer2.WriteStartElement("setProdotti");
                writer2.WriteStartElement("streams");
                writer2.WriteStartElement("instream");
                xmlserializer.Serialize(writer2, p, ns);
                writer2.Dispose();
                string serializedXml = stringWriter.ToString();
