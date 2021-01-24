    public class MyResolver : DataContractResolver
    {
        public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            string name = string.Empty;
            bool isFound = false;
            if (type.Name == "Int32[]")
            {
                name = "IntArray";
                isFound = true;
            }
            if (type.Name.Contains("List") && type.FullName.Contains("Int")) //find List<int>
            {
                name = "IntList";
                isFound = true;
            }
            if (type.Name.Contains("Collection") && type.FullName.Contains("Int")) //find Collection<int> 
            {
                name = "IntCollection";
                isFound = true;
            }
    
            if (isFound)
            {
                XmlDictionary dictionary = new XmlDictionary();
                typeName = dictionary.Add(name);
                typeNamespace = dictionary.Add("http://tempuri.com");
                return true;
            }
    
            return knownTypeResolver.TryResolveType(type, declaredType, knownTypeResolver, out typeName, out typeNamespace);
        }
    
        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            if (typeName == "IntArray" )
            {
                return typeof(int[]);
            }
            if (typeName == "IntList")
            {
                return typeof(List<int>);
            }
            if (typeName == "IntCollection")
            {
                return typeof(Collection<int>);
            }
    
    
            return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null);
        }
    }
