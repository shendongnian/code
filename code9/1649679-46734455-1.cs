    public static T Deserialize<T>(string response)
    {
        var serializer = new XmlSerializer(typeof(T));
        using(TextReader reader = new StringReader(response))
        {
            return (T)serializer.Deserialize(reader);
        }
    }
