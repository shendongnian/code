    private static string name;
    private static void SetName()
    {
        Console.WriteLine("What is your name?");
        name = Console.ReadLine();
    }
    public static string ReturnName()
    {
        return name;
    }
