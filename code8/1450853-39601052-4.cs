    var xDoc = XDocument.Load(filename);
            
    var @namespace = "urn:hl7-org:v3";
    XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xDoc.CreateNavigator().NameTable);
    namespaceManager.AddNamespace("ns", @namespace);
    XNamespace ns = @namespace;
            
    var names = xDoc.XPathSelectElements("//ns:patient/ns:name", namespaceManager).ToList();
    var list = names.Select(p => new
                     {
                         Given = string.Join(", ", p.Elements(ns + "given").Select(x => (string)x)),
                         Family = (string)p.Element(ns + "family"),
                         BirthTime = new DateTime(1970,1,1).AddSeconds( (int)p.Parent.Element(ns + "birthTime").Attribute("value"))
                     })
               .ToList();
