    class DecoratorSerializer : IMessageSerializer
    {
        IMessageSerializer xmlSerializer;
        IMessageSerializer jsonSerializer;
    
        public DecoratorSerializer(IMessageSerializer xmlSerializer, IMessageSerializer jsonSerializer)
        {
            this.xmlSerializer = xmlSerializer;
            this.jsonSerializer = jsonSerializer;
        }
    
        public void Serialize(object message, Stream stream)
        {
            if (message.GetType() == typeof(MyMessage))
            {
                xmlSerializer.Serialize(message, stream);
            }
            else
            {
                jsonSerializer.Serialize(message, stream);
            }
        }
    
        public object[] Deserialize(Stream stream, IList<Type> messageTypes = null)
        {
            return jsonSerializer.Deserialize(stream, messageTypes);
        }
    
        public string ContentType
        {
            get { return jsonSerializer.ContentType; }
        }
    }
