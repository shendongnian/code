    public static void Run()
    {
        Task<int> i = Print1();
        Task<int> k = Print2();
        Task.WaitAll(i, k);
    }
