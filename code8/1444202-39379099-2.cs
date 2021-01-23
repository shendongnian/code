    static Func<IniConfig, object> getAction(string xType)
    {
        Func<IniConfig, object>> inDictionary;
        if (typeMapping.TryGetValue(xType, out inDictionary)
        {
            return inDictionary;
        }
        else
        {
            return Error;
        }
    }
