    static void Main(string[] args)
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        var launchLocationFromAssembly = entryAssembly.Location;
        var appDomain = AppDomain.CurrentDomain;
        var launchLocationFromAppDomain = appDomain.BaseDirectory;
        Console.WriteLine(launchLocationFromAssembly);
        Console.WriteLine(launchLocationFromAppDomain);
    }
