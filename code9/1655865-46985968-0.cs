    var xmlDoc = new XmlDocument();
    xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    
    var nodeRegion = xmlDoc.CreateElement("myCustomSetting ");
    nodeRegion.SetAttribute("firstValue", "value1");
    nodeRegion.SetAttribute("secondValue", "value2");
    
    xmlDoc.SelectSingleNode("//myCustomSetting").AppendChild(nodeRegion);
    xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    
