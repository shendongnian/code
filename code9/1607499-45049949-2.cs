    public static string DeSerialize<T>(string xml)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.PreserveWhitespace = false;
        xmlDoc.LoadXml(xml);
    
        Config config = Serializer.DeSerialize<Config>(xmlDoc.DocumentElement);
        string code = config.Login.Code;
        string password = config.Login.Pass;
    
        return code + "+" + password;
    } 
