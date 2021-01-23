    public static void Main(string[] args)
    {
        Assembly a = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mods\\ExampleMod.dll"));
        var x1 = a.GetType("PTF_Mod.Mod_Main");
        var x2 = x1.GetMethod("OnStart", BindingFlags.Static | BindingFlags.Public);
        var x3 = x2.Invoke(null, null);
        while(true);
    }
