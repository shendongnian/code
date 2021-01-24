    StringBuilder sb = new StringBuilder();
    XmlWriterSettings xws = new XmlWriterSettings();
    xws.OmitXmlDeclaration = true;
    xws.Indent = true;
    using (XmlWriter xw = XmlWriter.Create(sb, xws)) 
    {
       XElement child2 = new XElement("AnotherChild",
        new XElement("GrandChild", "different content"));
       child2.WriteTo(xw);
       xw.WriteEndElement();
    }
    Console.WriteLine(sb.ToString());
