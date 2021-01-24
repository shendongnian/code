    private static void Run()
    {
        var demoClasses = new List<object> { new DemoClass1(), new DemoClass2 ()};
        foreach (var demoClass in demoClasses)
        {
            var implementation = demoClass as IDemoInterface;
            implementation?.DemoMethod();
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
