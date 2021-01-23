    #if DEBUG
    public void DoSomething() { }
    #endif
    public void Foo()
    {
        #if DEBUG
        DoSomething(); 
        #endif
    }
