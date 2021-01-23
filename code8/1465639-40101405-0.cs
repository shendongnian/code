    string xmlFile = Server.MapPath("~/HCConfig/HCUOM.xml");
    XDocument doc = XDocument.Load(xmlFile );
    
    var nodeList = doc.Descendants("ActiveDimensionSymbol");
    string ActiveDimensionSymbol = string.Empty;
    foreach (var node in nodeList)
    {
       ActiveDimensionSymbol = node.Value;
    }
