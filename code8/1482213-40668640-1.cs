            const string ElementNamespace = "http://www.buzonfiscal.com/ns/xsd/bf/remision/52";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            var serializer = new XmlSerializer(typeof(Remision));            
            var commRemision = new Remision
            {
                Version = "5.2",
                InfoBasica = new InfoBasica { Folio = "10240" },
                Addenda = new Addenda
                {
                    AddendaBuzonFiscal = new AddendaBuzonFiscal
                    {
                        Version = "2.0",
                        Emisor = new Emisor { Telefono = "8787826600" },
                        Receptor = new Receptor { Telefono = "1234567" },
                        TipoDocumento = new TipoDocumento { NombreCorto = "FAC" }
                    }
                }
            };
            XmlSerializerNamespaces xmlNamespace = new XmlSerializerNamespaces();
            xmlNamespace.Add(string.Empty, ElementNamespace);
            using(var stream = new MemoryStream())
            {
                using(var writer = new StreamWriter(stream))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(writer, settings))
                    {
                        serializer.Serialize(xmlWriter, commRemision, xmlNamespace);
                    }
                    stream.Position = 0;
                    using (var reader = new StreamReader(stream))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
            Console.ReadLine();
