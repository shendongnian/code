    //Specify path
    string webConfigFile = @"\web.config";
    //Load the document and get the default configuration namespace
    XDocument doc = XDocument.Load(webConfigFile);
    XNamespace netConfigNamespace = doc.Root.GetDefaultNamespace();
    //Get and edit the settings
    IEnumerable<XElement> settings = doc.Descendants(netConfigNamespace + "appSettings").Elements();
    XElement versionPsmNode = settings.FirstOrDefault(a => a.Attribute("key").Value == "Version_PSM");
    versionPsmNode?.Attribute("value").SetValue("New value");
    //Save the document with the correct namespace
    doc.Root.Name = netConfigNamespace + doc.Root.Name.LocalName;
    doc.Save(webConfigFile);
