    static void Main()
    {
        var task = Task.Run(new Action(MyMethod));
    }
    static void MyMethod()
    {
        Console.WriteLine("MyMethod()");
    }
