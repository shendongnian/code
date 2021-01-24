    public static void Main(string[] args)
    {
        MyClass messageReciever = new MyClass();
        messageReciever.StartRecievingMessages();
        Console.WriteLine("Press Q to exit...");
        while (Console.ReadKey(true).Key != ConsoleKey.Q) { }
    }
