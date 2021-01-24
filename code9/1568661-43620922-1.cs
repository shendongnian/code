    public void Test()
    {
        var methods = new MyMethods();
        Console.WriteLine(methods.GetTestString("test", 3));
        Console.WriteLine(methods.GetSomeLoremIpsumText("lorem", int.MaxValue));
    }
