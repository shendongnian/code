    using (var reader = XmlReader.Create("test.xml"))
    using (var writer = XmlWriter.Create("test2.xml"))
    {
        writer.WriteStartElement("X");
        reader.MoveToContent();
        writer.WriteNode(reader.ReadSubtree(), true);
        writer.WriteEndElement();
    }
