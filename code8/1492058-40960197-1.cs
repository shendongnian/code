    public IEnumerable<XElement> ReadFile(string pathToTheFile)
    {
        using (XmlReader reader = XmlReader.Create(pathToTheFile))
        {
            reader.MoveToContent();
            while (reader.Read())
            {
                If (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("yourElementName"))
                    {
                        XElement element = XElement.ReadFrom(reader) as XElement;
                        yield return element ;
                    }
                }
            }
        }
    }
