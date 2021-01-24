    XDocument doc;
    using (var xmlReader = XmlReader.Create(tempFile))
    {
        doc = XDocument.Load(xmlReader);
    }
    var rootName = doc.Root.Name;
    doc.Root.Name = "Bookings";
    var deserializer = new XmlSerializer(typeof(Bookings));
    Bookings bookings;
    using (var xmlReader = doc.CreateReader())
    {
        bookings = (Bookings)deserializer.Deserialize(xmlReader);
    }
