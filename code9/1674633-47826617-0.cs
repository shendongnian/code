    public static void Main(string[] args)
    {
    	if (Debugger.IsAttached || args.Contains("--debug"))
    	{
    		BuildWebHost(args).Run();
    	}
    	else
    	{
    		var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    		Directory.SetCurrentDirectory(path);
    		BuildWebHost(args).RunAsService();
    	}
    }
