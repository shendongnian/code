    public class DummySerializer : ISerializer
    {
        // You can test these properties in the unit test after the call;
        public StreamWriter Writer { get; private set; }
        public object Value { get; private set; }
        public XmlSerializerNamespaces NS { get; private set; }
        public int Calls { get; private set; }
        public void Serialize(StreamWriter writer, object value, XmlSerializerNamespaces ns)
        {
            Writer = writer;
            Value = value;
            NS = ns;
            Calls++;
        }
    }
