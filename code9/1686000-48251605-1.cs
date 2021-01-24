    System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
    xd.LoadXml(yourxmlstring);
    System.Xml.XmlElement root = xd.DocumentElement;
    System.Xml.XmlNodeList nl = root.SelectNodes("//remittance/contain");
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    foreach (System.Xml.XmlNode xnode in nl.Item(0).ChildNodes)
    {
        string name = xnode.Name;
        string value = xnode.InnerText;
        dictionary.Add(name, value);
        }
