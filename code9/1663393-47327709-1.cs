    XmlNode CreateAndAppendChild(XmlDocument xmlWriter, XmlNode parent, string name, string innerText, params Tuple<string, string> attributes)
    {
        var child = xmlWriter.CreateElement(name);
        foreach(var attribute in attributes)
        {
            child.SetAttribute(attribute.Item1, attribute.Item2);
        }
        child.InnerText = innerText;
        parent.AppendChild(child);
        return child;
    }
