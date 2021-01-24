    public void Test()
    {
        Console.WriteLine(CallMethodByAccessor("test",3));
        Console.WriteLine(CallMethodByAccessor("lorem",int.MaxValue));
        Console.WriteLine(CallMethodByAccessor("I-do-not-exist",0));
    }
