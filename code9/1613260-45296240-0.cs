    public class SharedTypeResolver : DataContractResolver
    {
        public override bool TryResolveType(Type dataContractType, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            if (!knownTypeResolver.TryResolveType(dataContractType, declaredType, null, out typeName, out typeNamespace))
            {
                XmlDictionary dictionary = new XmlDictionary();
                typeName = dictionary.Add(dataContractType.FullName);
                typeNamespace = dictionary.Add(dataContractType.Assembly.FullName);
            }
        }
        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null) ?? Type.GetType(typeName + ", " + typeNamespace);
        }
    }
