    public static class XmlSerializerExtensions
    {
        /// <summary>
        /// Deserializes the specified filename.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content">The content.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Deserializes the specified filename.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
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
