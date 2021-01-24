    var xDoc = XDocument.Load(kmlFileUrl);
    XNamespace ns = "http://www.opengis.net/kml/2.2";
    
    var elementsInFolder = xDoc.Root
        .Elements(ns + "Document")
        .Elements(ns + "Folder")
        .Elements(ns + "Placemark")
        .GroupBy(i => (string) i)
        .SelectMany(g => g.Skip(1))
        .ToList();
    
    var countInFolder = elementsInFolder.Count;
    elementsInFolder.Remove();
    
    var elementsInDocument = xDoc.Root
        .Elements(ns + "Document")
        .Elements(ns + "Placemark")
        .GroupBy(i => (string) i)
        .SelectMany(g => g.Skip(1))
        .ToList();
    
    var countInDocument = elementsInDocument.Count;
    elementsInDocument.Remove();
    
    int totalRemoved = countInFolder + countInDocument;
