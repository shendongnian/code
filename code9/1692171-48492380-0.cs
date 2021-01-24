    public async static Task<int> AsyncFunction(int x) 
        => await SomeAsyncMethodThatReturnsTaskOfInt();
    public static Task<int> SyncFunction(int x) 
        => Task.FromResult(SomeSyncMethodThatReturnsInt());
    public async static void AsyncChain()
    {
        int i = await AsyncFunction(10)
            .MapAsync(SyncFunction);
        Console.WriteLine("The result = {0}", i);
    }
