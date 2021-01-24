    public void ReadMyXml(XmlReader reader)
    {
        XmlReaderSettings settings = reader.Settings ?? new XmlReaderSettings();
		settings.IgnoreWhitespace = true;
		using(XmlReader myReader = XmlReader.Create(reader, settings))
        {
            // use myReader to read the xml
        }
    }
