    using (var stream = new FileStream("My xml file", FileMode.Open))
    {
        var isErrorOccurred = false;
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ValidationType = ValidationType.Schema;
        settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
        settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
        settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
        settings.Schemas.Add("", "my schema");
        settings.ValidationEventHandler += (sender, args) =>
        {
            isErrorOccurred = true;
            Console.WriteLine("{0}", args.Exception.LineNumber);;
        };
        stream.Seek(0, SeekOrigin.Begin);
        XmlReader reader = XmlReader.Create(stream, settings);
        // Parse the file. 
        while (reader.Read())
        {}
        if (isErrorOccurred)
            // do something
    }
