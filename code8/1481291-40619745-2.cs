    public class MyXmlSerializer : ISerializer
    {
        private XmlSerializer _xmlSerializer;
        public MyXmlSerializer(Type newType)
        {
            _xmlSerializer = new XmlSerializer(newType);
        }
        public void Serialize(StreamWriter writer, object value, XmlSerializerNamespaces ns)
        {
            _xmlSerializer.Serialize(writer, value, ns);
        }
    }
