    static entry[] DeserializeEntries(string filePath)
    {
        var settings = new XmlReaderSettings
        {
            // Allow processing of DTD
            DtdProcessing = DtdProcessing.Parse,
			// On older versions of .Net instead set 
			//ProhibitDtd = false,
            // But for security, prevent DOS attacks by limiting the total number of characters that can be expanded to something sane.
            MaxCharactersFromEntities = (long)1e7,
            // And for security, disable resolution of entities from external documents.
            XmlResolver = null,
        };
        using (var reader = new StreamReader(filePath, Encoding.UTF8))
        using (var xmlReader = XmlReader.Create(reader, settings))
        {
            var serializer = new XmlSerializer(typeof(entry[]), new XmlRootAttribute("JMdict"));
            return (entry[])serializer.Deserialize(xmlReader);
        }
    }
