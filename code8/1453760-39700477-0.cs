    XmlDocument originalXml = new XmlDocument();
    originalXml.Load(strDBDir);
    var TechReport = originalXml.SelectSingleNode($"tblTemp/Details[AId={AId}][LoginId={LoginId}]");
    if (TechReport != null)
    {
      XmlNode Data = originalXml.CreateNode(XmlNodeType.Element, "FDate", null);
      TechReport.AppendChild(Data);
      originalXml.Save(strDBDir);
    }
    else
    {
      // Handle this as you see fit...
    }
