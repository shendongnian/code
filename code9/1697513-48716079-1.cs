    private static void Main()
    {
        var demoClasses = new List<IDemoInterface> {new DemoClass1(), new DemoClass2()};
        foreach (var demoClass in demoClasses)
        {
            demoClass.DemoMethod();
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
