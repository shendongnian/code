    public string CallCalcOfSomeObject(object obj, string methodName, params object[] parameters)
    {
        var type = obj.GetType();
        var method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
    
        return (string)method?.Invoke(obj, parameters);
    }
