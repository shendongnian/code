    public Type GetTypeFromString(String typeName)
    {
        foreach (Assembly theAssembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            Type theType = theAssembly.GetType(typeName);
            if (theType != null)
            {
                return theType;                    
            }
        }
        return null;
    }
 
