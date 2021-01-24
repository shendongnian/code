    public void AddUserXml()
    {
        XmlDocument xml = new XmlDocument();
        xml.Load("user.xml");                
        var userNode = xml.SelectSingleNode("user");
        var userNameNode = userNode.SelectSingleNode("username");
        userNameNode.InnerText = Username;
        xml.Save("user.xml");
    }
