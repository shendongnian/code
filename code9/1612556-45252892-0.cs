    var doc = XDocument.Load(@"C:\Temp\Source.xml");
    doc.Descendants().Attributes().Where(x => x.IsNamespaceDeclaration).Remove();
    doc.Root.Add(new XAttribute(XNamespace.Xmlns + "root", "urn:root:v1"));
    doc.Root.Add(new XAttribute(XNamespace.Xmlns + "loc", "urn:location:v2"));
    doc.Save(@"C:\Temp\Target.xml");
