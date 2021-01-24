    string xmlDoc = "";
    
    // Use a memory stream to avoid the .net internal string utf-16 encoding pitfall.
    using (MemoryStream xmlStream = new MemoryStream())
    using (XmlReader xmlReader = XmlReader.Create(new StringReader(xmlAsText)))
    using (XmlReader xsltReader = XmlReader.Create(new StringReader(xsltAsText)))
    {
    	// Transform XML string to new XML based on the XSLT
    	// Load the XSLT and transform source XML to target XML
    	XslCompiledTransform myXslTrans = new XslCompiledTransform();
    	myXslTrans.Load(xsltReader);
    	myXslTrans.Transform(xmlReader, null, xmlStream);
    
    	// Using the encoding from the xslt, transform the xml stream bytes to the xml string.
    	// If no encoding in xslt, defaults to UTF-8.
    	xmlDoc = myXslTrans.OutputSettings.Encoding.GetString(xmlStream.ToArray());
        // Remove the BOM if it exists
        string byteOrderMark = myXslTrans.OutputSettings.Encoding.GetString(myXslTrans.OutputSettings.Encoding.GetPreamble());
        if (xmlDoc.StartsWith(byteOrderMark, StringComparison.Ordinal))
        {
            xmlDoc = xmlDoc.Remove(0, byteOrderMark.Length);
        }
    }
