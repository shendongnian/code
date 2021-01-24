    private static string name;
    static void Main(string[] args)
    {
        SetName();
        Console.WriteLine("Name: " + ReturnName());
    }
    private static void SetName()
    {
        Console.WriteLine("What is your name?");
        name = Console.ReadLine();
    }
    public static string ReturnName()
    {
        return name;
    }
