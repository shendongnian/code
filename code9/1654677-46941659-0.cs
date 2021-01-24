    static void Main(string[] args)
    {
        new Program().TestMethod();
    }
    private void TestMethod([CallerMemberName]string caller = "")
    {
        Console.WriteLine(caller);
        Console.ReadLine();
    }
