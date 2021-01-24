    public static async Task Run()
    {
        Task<int> i = Print1();
        Task<int> k = Print2();
        await Task.WhenAll(i, k);
    }
    public static void Main(string[] args)
    {
        Run().GetAwaiter().GetResult();
    }
