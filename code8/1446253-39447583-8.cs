    // Mapping attribute
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class MessageProcessorAttribute : Attribute
    {
        public MessageProcessorAttribute(Type messageType)
        {
            MessageType = messageType;
        }
        public Type MessageType { get; }
    }
