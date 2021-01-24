    private T Deserialize<T>(string path) where T : class
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        T result = null;
        using (XmlReader reader = XmlReader.Create(path))
        {
           result = (T)serializer.Deserialize(reader);
        }
        return result;
    }
