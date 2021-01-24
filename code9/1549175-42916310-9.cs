    static void Main()
    {
        foreach(int x in Enumerable.Repeat(5/*value for X*/, 1/*single run*/))
        {
            x=4;   // <- compile time error!
            Console.WriteLine(x);
        }
    }
