    [DllExport("Init", CallingConvention.StdCall)]
    public static void Init()
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
    }
    private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
    {
        string location = Assembly.GetExecutingAssembly().Location;
        AssemblyName name = new AssemblyName(args.Name);
        string path = Path.Combine(Path.GetDirectoryName(location), name.Name + ".dll");
        if (File.Exists(path))
        {
            return Assembly.LoadFrom(path);
        }
        return null;
    }
