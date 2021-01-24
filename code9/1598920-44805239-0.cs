    XmlWriterSettings settings = new XmlWriterSettings();
	settings.Indent = true;
	settings.NewLineOnAttributes = false; // Behavior changed in PrettyXmlWriter
	settings.OmitXmlDeclaration = true;
	using(TextWriter rawwriter = File.CreateText(filepath))
	using (XmlWriter writer = XmlWriter.Create(rawwriter, settings))
	{
		// rawwriter is used both by XmlWriter and PrettyXmlWriter
		PrettyXmlWriter outputter = new PrettyXmlWriter(writer, rawwriter);
		outputter.Write(MyXml);
					
		writer.Flush();
		writer.Close();
	}
