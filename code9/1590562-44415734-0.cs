    public string SerializeObjectToXml<T>(T obj)
    {
        var sb = new StringBuilder();
        using (var wrt = new StringWriter(sb))
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            xs.Serialize(wrt, obj);
        }
    
        return sb.ToString();
    }
