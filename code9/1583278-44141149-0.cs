    var query1 = 
        from track in cdXml.Root.Elements("Tracks")
        from track2 in myXMLDoc.Root.Element("album").Element("tracks").Elements("track")
        where !track2.Element("name").Value.Contains(track.Element("Titel").Value)
        select track2;
    query1 = query1.ToList();
    //  Put a breakpoint HERE and examine query1 in the debugger to 
    //  see what you got
    ;
    foreach (var element in query1)
    {
        cdXml.Element("Tracks").Add(
            new XElement("Artiest", element.Element("name").Value),
            new XElement("Titel", element.Element("artist").Element("name").Value),
            new XElement("Lengte", element.Element("duration").Value));
    }
