    public static async Task MainAsync(string[] args)
    {
        //do stuff here
    }
    
    public static void Main(string[] args)
    {
        MainAsync(args).Wait();
    }
