    static void Main()
    {
        Console.WriteLine(new Test().Method(1, 2));
        var plugin       = Assembly.LoadFile(Path.GetFullPath("PluginLibrary.dll"));
        var testClass    = plugin.GetType("PluginLibrary.Plugin");
        var testInstance = Activator.CreateInstance(testClass);
        var method       = testClass.GetMethod("Test");
        int result       = (int) method.Invoke(testInstance, null);
        Console.WriteLine(result);
    }
