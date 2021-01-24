    public IMyInterface CreateRawResponse()
    {
        if (condition)
        {
            return new A
            {
                Name = "A"
            };
        }
        else
        {
            return new B
            {
                Name = "B"
            };
        }
    }
    public string CreateResponse(IMyInterface myInterface)
    {
        return myInterface.Name;
    }
    public string CreateResponseForA(A a)
    {
        return a.Name;
    }
    public string CreateResponseForB(B b)
    {
        return b.Name;
    }
