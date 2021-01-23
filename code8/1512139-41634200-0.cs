	using (var writer = XmlWriter.Create(Console.Out))
	{
		writer.WriteStartElement("root");
		writer.WriteStartElement("child");
		writer.WriteWhitespace("\n");
		writer.WriteStartElement("child-on-new-line");
		writer.WriteString("content");
		writer.WriteEndElement();
		writer.WriteEndElement();
		writer.WriteEndElement();
    }
