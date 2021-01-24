    public IMyObj Create<T>(string param1, int param2) where T : MyObj1 
    {
        return (IMyObj)Activator.CreateInstance(typeof(T),args);
    }
    public IMyObj Create<T>(bool param1, string param2, int param3) where T : MyObj2 
    {
        return (IMyObj)Activator.CreateInstance(typeof(T),args);
    }
    ...
    ...
