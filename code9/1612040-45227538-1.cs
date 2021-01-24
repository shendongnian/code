    static void Main()
    {
        string name = GetUserName();
        Console.WriteLine("Hello, " + name + ". Nice to meet you!");
        Console.ReadKey();
    }
    public static string GetUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
