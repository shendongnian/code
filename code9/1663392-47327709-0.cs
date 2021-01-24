    void CreateAndAppendChild(XmlNode parent, string name, params Tuple<string, string> attributes)
    {
        var child = xmlWriter.CreateElement(name);
        foreach(var attribute in attributes)
        {
            child.SetAttribute(attribute.Item1, attribute.Item2);
        }
        parent.AppendChild(child);
    }
