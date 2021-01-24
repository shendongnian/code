    static void Main(string[] args)
    {
        new Program().TestMethod();
        Console.ReadLine();
    }
    private async void TestMethod([CallerMemberName]string caller = "")
    {
        Console.WriteLine(caller);
    }
