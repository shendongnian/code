    var doc = XDocument.Load("data.xml");
    var hdr = xdoc.Root.Element("Hdr");
    var elements = hdr.Elements().ToList(); 
    hdr.RemoveAll(); // we can remove child elements, because they are stored in a list
    hdr.Value = "";  // otherwise xdoc will compact empty element to <Hdr/>
    // calculating size of sub-document 'template'
    var sb = new StringBuilder();
    using (XmlWriter writer = XmlWriter.Create(sb))
        doc.Save(writer);
    var outerSizeInBytes = ASCIIEncoding.ASCII.GetByteCount(sb.ToString());
    
    var maxSizeInBytes = 100;
    var subDocumentIndex = 0; // used just for naming sub-document files
    var subDocumentSizeBytes = outerSizeInBytes; // initial size of any sub-document
    var subDocument = new XDocument(doc); // clone 'template'
    foreach (var smt in elements)
    {
        var currentElementSizeBytes = ASCIIEncoding.ASCII.GetByteCount(smt.ToString());
        subDocumentSizeBytes += currentElementSizeBytes;
        if (maxSizeInBytes < subDocumentSizeBytes)
        {
            subDocument.Save($"doc{++subDocumentIndex}.xml");
            subDocument = new XDocument(doc);
            subDocumentSizeBytes = outerSizeInBytes + currentElementSizeBytes;
        }
        subDocument.Root.Element("Hdr").Add(smt);
    }
    // if current sub-document has elements added, save it too
    if (outerSizeInBytes < subDocumentSizeBytes)
        subDocument.Save($"doc{++subDocumentIndex}.xml");
