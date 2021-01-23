    public class DeserializeAsBaseResolver : DataContractResolver
    {
        public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            return knownTypeResolver.TryResolveType(type, declaredType, null, out typeName, out typeNamespace);
        }
        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null) ?? declaredType;
        }
    }
