    public static class XmlSerializerExtensions
    {
        public static T DeserializeFromNonStandardXmlString<T>(string content)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(content);
            var serializer = typeof(T).IsGenericType ? new XmlSerializer(typeof(T), typeof(T).GenericTypeArguments) : new XmlSerializer(typeof(T));
            using (var reader = new XmlNodeReader(xmlDoc))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        public static object DeserializeFromNonStandardXmlString(Type type, string content)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(content);
            var serializer = type.IsGenericType ? new XmlSerializer(type, type.GenericTypeArguments) : new XmlSerializer(type);
            using (var reader = new XmlNodeReader(xmlDoc))
            {
                return serializer.Deserialize(reader);
            }
        }
    }
