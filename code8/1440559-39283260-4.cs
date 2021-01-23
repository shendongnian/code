    public static partial class XmlSerializationExtensions
    {
        public static void SerializeToXmlFile<T>(this T obj, string fileName)
        {
            var settings = new XmlWriterSettings { Indent = true };
            using (var writer = XmlWriter.Create(fileName, settings))
            {
                new XmlSerializer(typeof(T)).Serialize(writer, obj);
            }
        }
        public static T DeserializeFromXmlFile<T>(string fileName)
        {
            using (var reader = XmlReader.Create(fileName))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }
    }
