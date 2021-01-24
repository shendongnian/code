    public static T XmlDeserializer<T>(string xmlString)
    {
        var instance = default(T);
        var xmlSerializer = new XmlSerializer(typeof(T));
        using (var stringreader = new StringReader(xmlString))
            instance = (T)xmlSerializer.Deserialize(stringreader);
        return instance;
    }
