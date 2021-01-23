    public void Test() 
    {
       InvokeFunction(() => Test1("st", "sn"));
    }
    
    public void InvokeFunction(Action f)
    { 
        f();
    }
    
    public void Test1(string sT, string sFN)
    {
        Console.WriteLine(sT + " : " + sFN);
    }
