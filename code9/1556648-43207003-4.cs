    XElement xml;
    var readerSettings = new XmlReaderSettings();
    readerSettings.ValidationType = ValidationType.Schema; // <--
    readerSettings.Schemas.Add("", "data.xsd"); // <--
    using (var reader = XmlReader.Create("data.xml", readerSettings)) // <--
    {
        xml = XElement.Load(reader);
    }
    xml.Save(Console.Out);
    Console.WriteLine();
