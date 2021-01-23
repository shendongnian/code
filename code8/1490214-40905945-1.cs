            var report = new InventoryReportMessage
            {
                Header = new StandartBusinessDocumentHeader {
                    HeaderVersion = "Standard Business Header version 1.3",
                    Sender = new Sender
                    {
                        Identifier = new Identifier
                        {
                            Authority = "GS1",
                            Value = "0000"
                        },
                        ContactInformation = new ContactInformation
                        {
                            Contact = "some one",
                            EmailAddress = "someone@example.com",
                            TelephoneNumber = "00357",
                            ContactTypeIdentifier = "IT Support"
                        }
                    }
                }
            };
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    var settings = new XmlWriterSettings { 
                       Indent = true
                    };
                    using (var xmlWriter = XmlWriter.Create(writer, settings))
                    {
                        xmlWriter.WriteStartDocument(false);
                        var serializer = new XmlSerializer(typeof(InventoryReportMessage));
                        var namespaces = new XmlSerializerNamespaces();
                        namespaces.Add("inventory_report", "urn:gs1:ecom:inventory_report:xsd:3");
                        namespaces.Add("sh", "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader");
                        namespaces.Add("ecom_common", "urn:gs1:ecom:ecom_common:xsd:3");
                        namespaces.Add("shared_common", "urn:gs1:shared:shared_common:xsd:3");
                        serializer.Serialize(xmlWriter, report, namespaces);
                    }
                    stream.Position = 0;
                    using (var reader = new StreamReader(stream))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
            Console.ReadLine();
