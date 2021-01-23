    static void printFirstMessage()
    {
         Console.WriteLine("Bar");
    }
    
    static void printSecondMessage()
    {
        Console.WriteLine("Baz");
    }
    
    public static void Main(string[] args)
    {
        Task FooTask = Task.Run(() => printFirstMessage())
            .ContinueWith(t => printSecondMessage());
        Console.WriteLine("Press Enter To Exit.");
        Console.ReadLine();
    }
