    XmlDocument xmlDocument = ConstructXMLFromDataBase();
    XDocument document;
    using (var nodeReader = new new XmlNodeReader(xmlDocument))
    {
        document = XDocument.Load(nodeReader);    
    }
    
    var storeIdCollection = GetMyCollection().Select(myObject => myObject.StoreId);
    var storeIds = new HashSet<string>(storeIdCollection);
    var nodes = document.Descendants.Where(node => node.Attribute("Value") != null);
    foreach(var node In nodes)
    {
        var storeId = node.Attribute("Value").Value;
        If (storeIds.Contains(storeId))
        {
            node.Attribute("Checked").Value = "true";
        }
    }
    
