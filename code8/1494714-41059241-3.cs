    static void GetPlayer1(ref string name1)
    {
        Console.WriteLine("PlayerX enter your name:");
        name1 = Console.ReadLine();
    }
    static void GetPlayer2(ref string name2)
    {
        Console.WriteLine("PlayerO enter your name:");
        name2 = Console.ReadLine();
    }
    static void Main(string[] args)
    {
        string name1;
        string name2;
        GetPlayer1(ref name1);  // "ref" must now be specified, simply because
        GetPlayer2(ref name2);  // both methods also specify it.
    }
