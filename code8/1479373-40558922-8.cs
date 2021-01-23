    public static class ProtobufExtensions
    {
        public static T DeserializeOrMerge<T>(Stream stream)
        {
            if (!typeof(T).IsValueType
                && typeof(T) != typeof(string)
                // Test to make sure T has a public default constructor
                && typeof(T).GetConstructor(Type.EmptyTypes) != null
                && typeof(T).HasProtoIncludeAtributes())
            {
                return ProtoBuf.Serializer.Merge(stream, Activator.CreateInstance<T>());
            }
            else
            {
                return ProtoBuf.Serializer.Deserialize<T>(stream);
            }
        }
        public static bool HasProtoIncludeAtributes(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException();
            if (!type.IsDefined(typeof(ProtoContractAttribute)))
                return false;
            return type.BaseTypesAndSelf().SelectMany(t => t.GetCustomAttributes<ProtoIncludeAttribute>()).Any();
        }
        public static IEnumerable<Type> BaseTypesAndSelf(this Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }
    }
