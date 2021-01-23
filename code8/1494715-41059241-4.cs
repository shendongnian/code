    static string GetPlayer1()
    {
        Console.WriteLine("PlayerX enter your name:");
        return Console.ReadLine();
    }
    static string GetPlayer2()
    {
        Console.WriteLine("PlayerO enter your name:");
        return Console.ReadLine();
    }
    static void Main(string[] args)
    {
        string name1 = GetPlayer1();
        string name2 = GetPlayer2();
    }
