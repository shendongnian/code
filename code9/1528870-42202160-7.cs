    public string CallMethodOfSomeObject(object obj, string methodName, params object[] parameters)
    {
        var type = obj.GetType();        
        var method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
    
        //use this if you use C#6 or higher version
        return (string)method?.Invoke(obj, parameters);
        //use this if you use C#5 or lower version
        if (method == null)
        {
            return (string)method.Invoke(obj, parameters);            
        }
        return null;       
    }
