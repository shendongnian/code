    private static string input;
    public static void Main (string[] args)
    {
        Console.Write ("What is your name: ");
        input = Console.ReadLine ();
        sayHi ();
    }
    public static string sayHi() {
        Console.WriteLine ("Hello {0}!", input);
    }
