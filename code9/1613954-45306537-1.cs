    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    {
        writer.Write(xmlString);
        writer.Flush();
        stream.Position = 0;
        XmlSerializer serializer = new XmlSerializer(typeof(Order));
        Order o = (Order)serializer.Deserialize(stream);
    }
