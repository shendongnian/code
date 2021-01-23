    public XmlReader CleanXdocument(XmlReader xmlReader)
            {
                var xdoc = new XDocument();
                xdoc = XDocument.Load(xmlReader);
                if (xdoc.Descendants("cache").Any())
                {
                    xdoc.Descendants().FirstOrDefault(e => e.Name == "cache").Remove();
                }
                var str = xdoc.ToString();
                TextReader tr = new StringReader(str);
                xmlReader =XmlReader.Create(tr);
    
                return xmlReader;
            }
