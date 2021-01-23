    public void Test() 
    {
        var result = InvokeFunction(() => Test2(7));
        Console.WriteLine(result);
    }
    
    public T InvokeFunction<T>(Func<T> f)
    { 
        return f();
    }
    public string Test2(int p)
    {
        return p + "";
    }
