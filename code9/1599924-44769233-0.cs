    static void Main(string[] args)
    {
        //Your code, from the original post
        ObjectCache cache1 = MemoryCache.Default;
        object myObject = new object();
        CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
        cacheItemPolicy.SlidingExpiration = new TimeSpan(4, 0, 0);
        cache1.Add("My Object", myObject, cacheItemPolicy);
        ObjectCache cache2 = MemoryCache.Default;
        object cachedObject = cache2.Get("My Object");
        //Test the reference, output the result
        Console.WriteLine(ReferenceEquals(cache1, cache2)); //Outputs True
    }
