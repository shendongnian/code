    public static string Serialize<T>(T dataToSerialize)
    {
        try
        {
            var stringwriter = new ISOEncodingStringWriter();
            var serializer = new XmlSerializer(typeof(T));
            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            serializer.Serialize(stringwriter, dataToSerialize, xns);
            return stringwriter.ToString();
        }
        catch
        {
            throw;
        }
    }
    public static T Deserialize<T>(string xmlText)
    {
        try
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stringReader);
        }
        catch
        {
            throw;
        }
    }
