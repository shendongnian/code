            var settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
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
                        TipoDocumento = new TipoDocumento { NombreCorto = "FAC" },
                        Ns = "http://www.buzonfiscal.com/ns/addenda/bf/2"
                    }
                },
                Ns = "http://www.buzonfiscal.com/ns/xsd/bf/remision/52"
            };
            using(var stream = new MemoryStream())
            {
                using(var writer = new StreamWriter(stream))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(writer, settings))
                    {
                        commRemision.WriteXml(xmlWriter);
                    }
                    stream.Position = 0;
                    using (var reader = new StreamReader(stream))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
            Console.ReadLine();
