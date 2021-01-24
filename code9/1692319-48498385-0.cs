    XNamespace ns = "http://www.opengis.net/kml/2.2";
    xdoc.Root
        .Elements(ns+"Document")
        .Elements(ns+"Placemark")
        .GroupBy(i => (string)i)
        .SelectMany(g => g.Skip(1))
        .Remove();
