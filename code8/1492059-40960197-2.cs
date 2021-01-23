    public async Task<IEnumerable<XElement>> ReadFileAsync(string pathToTheFile)
    {
        var elements = new List<XElement>();
        var xmlSettings = new XmlReaderSettings { Async = true };
        using (XmlReader reader = XmlReader.Create(pathToTheFile, xmlSettings))
        {
            await reader.MoveToContentAsync();
            while (await reader.ReadAsync())
            {
                If (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("yourElementName"))
                    {
                        XElement element = XElement.ReadFrom(reader) as XElement;
                        elements.Add(element);
                    }
                }
            }
        }
        return elements;
    }
