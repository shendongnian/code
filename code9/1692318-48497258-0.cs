    XNamespace ns = "http://www.opengis.net/kml/2.2";
    var doc = XDocument.Load("file.xml");
    var query = doc.Root
                    .Element(ns + "Document")
                    .Elements(ns + "Placemark")
                    .Select(x => new  
                    {
                        Name = x.Element(ns + "name").Value,
                        Description = x.Element(ns + "description").Value,
                    })
                    .GroupBy(x => new { x.Name, x.Description })
                    .Select(g => g.First());
