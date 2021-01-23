    public void HandleObject(MyType value)
    {
        value.Member = 5;
    }
    public void Main()
    {
        MyType value = new MyType { Member = 3 };
        Console.WriteLine(value.Member);
        HandleObject(value);
        Console.WriteLine(value.Member);
        
        //Will print
        // 3
        // 5
    }
