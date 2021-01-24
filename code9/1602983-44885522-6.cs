    public static void Main(string[] args)
    {
        asyncclass asyncdemo = new asyncclass();
        asyncdemo.MainCall().Wait();
    }
