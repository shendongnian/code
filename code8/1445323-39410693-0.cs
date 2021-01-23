    //Dynamically created mock
    public int Add(int a, int b)
    {
        var context = new SubstitutionContext("Add", ...);
        //CallContext.LogicalSetData or
        //ThreadStatic or
        //ThreadLocal<T> or
        //...
        return 0;
    }
    
    //In some extension class
    public static ConfiguredCall Returns<T>(this T value, ...)
    {
        var context = SubstitutionContext.Current; //Gets from thread local storage
        return context.LastCallShouldReturn(value);
    }
