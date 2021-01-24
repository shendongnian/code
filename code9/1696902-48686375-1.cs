    public int Test(int a, int b) => a + b;
    public string Test(string a) => a + a;
    void Example()
    {
        Console.WriteLine(Retry(() => Test(1, 2)));
        Console.WriteLine(Retry(() => Test("a")));
    }
