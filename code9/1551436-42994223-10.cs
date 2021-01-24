    struct X { public int[] f; }
    static void Main()
    {
        X a;a.f = new []{5};
        X b;b = a;
        a.f[0]=4;
        Console.WriteLine("Hello " + b.f[0]); // FOUR!
    }
