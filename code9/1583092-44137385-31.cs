    Task<string> test(string x)
    {
        Console.WriteLine("Working");
        return Task.FromResult(x);
    }
    var cachedFunc=MemoizeAsync<string,string>(test);
    var results=await Task.WhenAll(cachedFunc("a"),cachedFunc("a"));
