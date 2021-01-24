    public Action<X> DoSomethingOverride {get; set;}
    public Action<X> DoSomething => doSomethingOverride ?? DefaultMethod;
    private void DefaultMethod (X param)
    {
    }
