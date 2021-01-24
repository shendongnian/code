    public static T DeSerialize<T>(string xml)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.PreserveWhitespace = false;
        xmlDoc.LoadXml(xml);
    
        XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
        XmlSerializer ser = new XmlSerializer(typeof(T));
    
        return (T)ser.Deserialize(reader);
    } 
