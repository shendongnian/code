    /// <summary>
    /// Deserialize an xml string to type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="xml"></param>
    /// <returns></returns>
    public static T Deserialize<T>(string xml)
    {
        if (string.IsNullOrEmpty(xml))
            return default(T);
    
        XmlSerializer serializer = new XmlSerializer(typeof(T));
    
        XmlReaderSettings settings = new XmlReaderSettings();
        // No settings need modifying here
    
        using (StringReader textReader = new StringReader(xml))
        {
            using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
            {
                return (T)serializer.Deserialize(xmlReader);
            }
        }
    }
