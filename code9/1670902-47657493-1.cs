    var xmlObj = new Dictionary<string, string>();
    using (var reader = XmlReader.Create(new StringReader(script)))
    {
        reader.Read();
        // add node name, i.e. type: L
        xmlObj.Add("type",reader.Name);
        // add all attributes
        while (reader.MoveToNextAttribute())
        {
            xmlObj.Add(reader.Name, reader.Value);
        }
    }
