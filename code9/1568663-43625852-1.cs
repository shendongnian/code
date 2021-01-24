    public string CallMethodByAccessor(string accessor, int i)
    {
        Func<int, string> methodToCall = FindMethodByAccessor(accessor);
        
        if (methodToCall == null)
            return DefaultMethod(i);
        else
            return methodToCall(i);
    }
    public string DefaultMethod(int i) { return "Unknown method requested!"; }
