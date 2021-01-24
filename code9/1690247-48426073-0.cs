    private static int _a;
    public static int a { get { return ++_a; } set { _a = value; } }
    static void Main(string[] args)
    {
        a = 0;
        if (a == 1 && a == 2 && a == 3)
        {
            Console.WriteLine("Hurraa");
        }
        Console.ReadLine();
    }
