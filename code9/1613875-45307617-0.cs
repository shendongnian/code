    public IEnumerable<XElement> ExecuteTestcase()
    {
        using (XmlReader aNodeReader = XmlReader.ReadSubtree()) 
        {
            yield return XElement.Load(aNodeReader);
        }
    }
