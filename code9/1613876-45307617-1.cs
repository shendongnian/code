    public IEnumerable<XElement> ExecuteTestcase()
    {
        using (var reader = XmlReader.Create(pathToXmlFile))
        using (var nodeReader = reader.ReadSubtree()) 
        {
            yield return XElement.Load(aNodeReader);
        }
    }
