    /// <summary> Convert XML Document to XDocument </summary>
    /// <param name="xmlDocument">Attached XML Document</param>
    public static XDocument fwToXDocument(this XmlDocument xmlDocument)
    {
        using (XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDocument))
        {
            xmlNodeReader.MoveToContent();
            return XDocument.Load(xmlNodeReader);
        }
    }
