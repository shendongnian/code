    foreach (XElement element in doc.Descendants("ProductData"))
    {
        foreach (XElement subElement in element.Elements())
        {
            Debug.WriteLine(subElement.Name.ToString());
            Debug.WriteLine(subElement.Value);
        }
    }
