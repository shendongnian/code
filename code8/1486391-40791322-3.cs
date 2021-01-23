    Files files;
    var settings = new XmlReaderSettings();
    settings.Schemas.Add("", "test.xsd");
    settings.ValidationType = ValidationType.Schema;
    var xs = new XmlSerializer(typeof(Files));
    using (var reader = XmlReader.Create("test.xml", settings))
    {
        files = (Files)xs.Deserialize(reader);
    }
