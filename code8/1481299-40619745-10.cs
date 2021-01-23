    public class MyXmlSerializer<T> : ISerializer
    {
        private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(T));
        public void Serialize(StreamWriter writer, object value, XmlSerializerNamespaces ns)
        {
            _xmlSerializer.Serialize(writer, value, ns);
        }
    }
