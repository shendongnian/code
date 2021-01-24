    // Variable set at this scope will be accessible to the whole class
    private static string userName;
    static void Main()
    {
        GetUserName();
        GreetUser();
        Console.ReadKey();
    }
    public static void GetUserName()
    {
        Console.Write("Please enter your name: ");
        userName = Console.ReadLine();
    }
    public static void GreetUser()
    {
        Console.WriteLine("Hello, " + userName + ". Nice to meet you!");
    }
