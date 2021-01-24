    static class StringFactory<T> where T : class
    {
        static private Dictionary<string, Type> s_dKnownTypes = new Dictionary<string, Type>();
        
        static StringFactory()
        {
            RegisterAll();
        }
        
        static private void RegisterAll()
        {
            var baseType = typeof(T);
            foreach (var domainAssembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in domainAssembly.GetTypes()
                    .Where(t => t.IsSubclassOf(baseType)))
                {
                    s_dKnownTypes.Add(type.Name, type);
                }
            }
        }
        
        static public T Create(string _sTypeName)
        {
            Type knownType;
            if (s_dKnownTypes.TryGetValue(_sTypeName, out knownType))
            {
                return (T)Activator.CreateInstance(knownType);
            }
            
            throw new KeyNotFoundException();
        }
    }
