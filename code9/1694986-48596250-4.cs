    NameTable nt = new NameTable();
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
    // this adds the missing namespace
    nsmgr.AddNamespace("xsi", "https://www.w3.org/2001/XMLSchema-instance");
    
    // Create the XmlParserContext.
    XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
    
    // Create the reader. 
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ConformanceLevel = ConformanceLevel.Fragment;
    XmlReader reader = XmlReader.Create(fileOrStream, settings, context);
    var xdoc = XDocument.Load(reader);
