    public static void Main()
    {
        TextWriter oldOut = Console.Out;
        TextWriter decorator = new MyCustomDecorator(oldOut);
        Console.SetOut(decorator);
    
        //Do stuff;
    }
