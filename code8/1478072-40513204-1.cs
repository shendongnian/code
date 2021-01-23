    public static object CreateInstance()
    {    
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.AssemblyResolve += MyResolveEventHandler;
        var assm = Assembly.LoadFrom("full.path.to.asm"));
        var objType = assm.GetType("MyType", true);
        var obj = Activator.CreateInstance(objType);
    }
    private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
    {
        if (args.Name == "SomeAssemblyIntheOtherFolder")
        {
            var path = Path.Combine(Path.GetDirectoryName("full.path.to.asm"), "SomeAssemblyIntheOtherFolder.dll");
            return Assembly.LoadFrom(path);
        }
        return null;
        
    }
