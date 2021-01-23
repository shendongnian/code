    static class Serializer
    {
        // note here: deserializeXml returns reference to deserialized instance
        public static T deserializeXml<T>(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var toDeserialize = (T)xmlSerializer.Deserialize(stream);
                return toDeserialize;
            }
        }
        public static void serializeToXml<T>(T instance, string filename)
        {
            var xmlSerializer = new XmlSerializer(instance.GetType());
            using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
            {
                xmlSerializer.Serialize(stream, instance);
            }
        }
    }
