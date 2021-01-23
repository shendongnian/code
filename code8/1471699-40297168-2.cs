    XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8", null));
    
    var root = new XElement("Root");
    
    var asset = new XElement("Asset");
    asset.Add(new XAttribute("InternalID", a.InternalID));
    asset.Add(new XAttribute("LastSaveDate", a.lastSaveDate));
    asset.Add(new XAttribute("LastSaveTime", a.lastSaveTime));
    asset.Add(new XAttribute("AssetType", a.AssetType));
    
    var type_metadata = new XElement("type_metadata");
    
    var field = new XElement("FIELD");
    field.Add(new XAttribute("name","filename"));
    field.Value = a.filename;
    
    type_metadata.Add(field);
    
    var field2 = new XElement("FIELD");
    field2.Add(new XAttribute("name","duration"));
    field2.Value = a.duration;
    
    type_metadata.Add(field2);
    asset.Add(type_metadata);
    root.Add(asset);
    doc.Add(root);
