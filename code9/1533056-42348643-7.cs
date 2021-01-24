    Bookings bookings = null;
    using (var xmlReader = XmlReader.Create(tempFile))
    {
        while (xmlReader.Read())
        {
            if (xmlReader.NodeType == XmlNodeType.Element)
            {
                var rootName = xmlReader.LocalName;
                var deserializer = new XmlSerializer(typeof(Bookings), new XmlRootAttribute { ElementName = rootName });
                bookings = (Bookings)deserializer.Deserialize(xmlReader);
                bookings.RootName = rootName;
                break;
            }
        }
    }
