    public static BaseClass ParseCode(string data)
    {
        ...
        string declaringType = MethodBase.GetCurrentMethod().DeclaringType; 
        return (BaseClass)Activator.CreateInstance(declaringType);
    }
