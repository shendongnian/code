    int count = 5;
    int length = 42;
    var writerSettings = new XmlWriterSettings { Indent = true };
    using (var writer = XmlWriter.Create("data.xml", writerSettings))
    {
        writer.WriteStartElement("Table");
        for (int i = 1; i <= count; i++)
        {
            writer.WriteStartElement("Rec");
            writer.WriteAttributeString("recId", i.ToString());
            writer.WriteString("..");
            writer.WriteEndElement();
        }
    }
