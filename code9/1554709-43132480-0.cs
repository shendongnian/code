    xmlDocument = new XDocument();
    xmlDocument = XDocument.Load(filePath, LoadOptions.None);
    
    var categoryNodeList = XmlDocument.Descendants("Category");
    
        foreach (XElement categoryItem in categoryNodeList)
        {
            foreach (XElement resourceItem in categoryItem.Elements())
            {
                var XmlObject = new ResultDetail
                {
                    Cause = categoryItem.Attribute("Cause").Value,
                    Component = resourceItem.Attribute("Component").Value,
                    Name = resourceItem.Attribute("Name").Value
                };
    		}
    	}
