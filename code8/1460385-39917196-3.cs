    public string GetBodyTagContent (string fileContent)
    {
        var xmlDoc = new System.Xml.XmlDocument();
        xmlDoc.LoadXml("<FileContent>" + fileContent + "</FileContent>");
        return string.Join(",", (from n in xmlDoc.SelectNodes("//body") select n.InnerText));
    }
 
