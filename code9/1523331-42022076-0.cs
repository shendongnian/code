    string YourXml = "<loop1><loop2><ID>001</ID><status code = \"A\">approve</status><status code = \"B\">deny</status></loop2></loop1>";
    XmlDocument xDoc = new XmlDocument();
    xDoc.LoadXml(YourXml); 
        XmlElement xelRoot = xDoc.DocumentElement;
    XmlNodeList xnlNodes = xelRoot.SelectNodes("//status"); //Deep search!!
    var sb = new StringBuilder();
    foreach (XmlNode xNode in xnlNodes) {
        sb.AppendLine( string.Format("code='{0}' value='{1}'", xNode.Attributes["code"].Value,xNode.InnerText));
    }
    string result = sb.ToString();
