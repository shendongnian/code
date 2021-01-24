    public delegate void Callback<in T>(T data);
        
    void MethodA(Callback<SomeBaseClass> theInstance)
    {
        MethodB(theInstance);
    }
    
    void MethodB<T>(Callback<T> theInstance) where T : SomeBaseClass
    {
    }
