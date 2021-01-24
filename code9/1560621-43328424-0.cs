    var doc = XDocument.Load("data.xml");
    var hdr = xdoc.Root.Element("Hdr");
    var elements = hdr.Elements().ToList();
    hdr.RemoveAll();
    hdr.Value = "";
    var sb = new StringBuilder();
    using (XmlWriter writer = XmlWriter.Create(sb))
        doc.Save(writer);
    var outerSizeInBytes = ASCIIEncoding.ASCII.GetByteCount(sb.ToString());
    var maxSizeInBytes = 100;
    var subDocumentIndex = 0;
    var subDocumentSizeBytes = outerSizeInBytes;
    var subDocument = new XDocument(xdoc);
    foreach (var smt in elements)
    {
        var currentElementSizeBytes = ASCIIEncoding.ASCII.GetByteCount(smt.ToString());
        subDocumentSizeBytes += currentElementSizeBytes;
        if (maxSizeInBytes < subDocumentSizeBytes)
        {
            subDocument.Save($"doc{++subDocumentIndex}.xml");
            subDocument = new XDocument(doc);
            subDocumentSizeBytes = outerSizeInBytes;
        }
        subDocument.Root.Element("Hdr").Add(smt);
    }
    if (outerSizeInBytes < subDocumentSizeBytes)
        subDocument.Save($"doc{++subDocumentIndex}.xml");
