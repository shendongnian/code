    public static string Serialize<T>(T objectToSerialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        StringWriter textWriter = new StringWriter();
        xmlSerializer.Serialize(textWriter, objectToSerialize);
        return textWriter.ToString();
    }
    public static T Deserialize<T>(string stringToDeserialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        StringReader textReader = new StringReader(stringToDeserialize);
        return (T)xmlSerializer.Deserialize(textReader);
    }
