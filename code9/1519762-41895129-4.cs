    public string CreateResponse(IMyInterface myInterface)
    {
        return myInterface.Name;
    }
    public string CreateResponseForA(A a)
    {
        return CreateResponse(a);
    }
    
    public string CreateResponseForB(B b)
    {
        return CreateResponse(b);
    }
