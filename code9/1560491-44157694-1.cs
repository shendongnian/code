    public XDocument Transform(string xml, string xsl)
    {
        var originalXml = XDocument.Load(new StringReader(xml));
    
        var transformedXml = new XDocument();
        using (var xmlWriter = transformedXml.CreateWriter())
        {
            var xslt = new XslCompiledTransform();
            xslt.Load(XmlReader.Create(new StringReader(xsl)));
    
            // Add XSLT parameters if you need
            XsltArgumentList xsltArguments = null; // new XsltArgumentList();
            // xsltArguments.AddParam(name, namespaceUri, parameter);
    
            xslt.Transform(originalXml.CreateReader(), xsltArguments, xmlWriter);
        }
    
        return transformedXml;
    }
