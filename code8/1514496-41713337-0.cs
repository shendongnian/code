      static void Main(string[] args)
            {
                Type findType = typeof(IBase);
                Type[] types = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                                from assemblyType in domainAssembly.GetTypes()
                                where findType.IsAssignableFrom(assemblyType)
                                select assemblyType).ToArray();
    
                for (int i = 0; i < types.Length; i++)
                {
                    PropertyInfo propertyInfo = types[i].GetProperty("GetType",  BindingFlags.Static| BindingFlags.FlattenHierarchy| BindingFlags.Public);
    
                    if (null != propertyInfo) // propertyInfo is NULL!
                    {
                        string getType = (string)propertyInfo.GetValue(null, null);
                    }
                }
            }
    
          
