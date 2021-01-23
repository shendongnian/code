    public struct SerializableType : IYamlConvertible
    {
        private Type type;
        void IYamlConvertible.Read(IParser parser, Type expectedType, ObjectDeserializer nestedObjectDeserializer)
        {
            var typeName = (string)nestedObjectDeserializer(typeof(string));
            type = typeName != null ? Type.GetType(typeName) : null;
        }
        void IYamlConvertible.Write(IEmitter emitter, ObjectSerializer nestedObjectSerializer)
        {
            nestedObjectSerializer(type != null ? type.AssemblyQualifiedName : null);
        }
        public static implicit operator Type(SerializableType value)
        {
            return value.type;
        }
        public static implicit operator SerializableType(Type value)
        {
            return new SerializableType { type = value };
        }
    }
