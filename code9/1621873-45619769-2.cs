    static List<string> GetInnerText(XmlDocument xDoc, string elementName)
    {
        List<string> innerText = new List<string>();
        var children = xDoc.GetElementsByTagName(elementName);
        foreach (XmlNode child in children)
            innerText.Add(child.InnerText);
        return innerText;
    }
