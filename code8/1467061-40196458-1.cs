    public static void Main()
    {
    	AppDomain.CurrentDomain.AssemblyLoad += OnAssemlyLoad;
        ...
    }
    static void OnAssemlyLoad(object sender, AssemblyLoadEventArgs args) 
    {
    	Console.WriteLine("Assembly Loaded: " + args.LoadedAssembly.FullName);
    }
