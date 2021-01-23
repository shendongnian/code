    public static void OnStart()
    {
        var exe = Assembly.GetCallingAssembly();
        Console.WriteLine(exe.Location); //Location is valid
        var x = exe.GetType("Engine.ModCrew+Mod", true); //But here I get exception
        var y = Activator.CreateInstance(x);
        x.GetMethod("ItWorks", BindingFlags.Instance | BindingFlags.Public).Invoke(y, null);
    }
