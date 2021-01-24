    static void Main(string[] args)
    {
        string name = AskName();
        Console.WriteLine($"Name: {name}.");
    }
    
    private static string AskName()
    {
        Console.WriteLine("What is your name?");
        return Console.ReadLine();
    }
