        public FileStreamResult GenerateXML()
        {
            MemoryStream ms = new MemoryStream();
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Indent = true;
            using (XmlWriter xw = XmlWriter.Create(ms, xws))
            {
                XDocument doc = new XDocument(
                 new XElement("Tidrans",
                  new XElement("tidkod", "role"),
                  new XElement("datum", "date"),
                  new XElement("timmar", "hours")
                 )
                );
                doc.WriteTo(xw);
            }
            ms.Position = 0;
            return File(ms, "text/xml", "Sample.xml");
        }
