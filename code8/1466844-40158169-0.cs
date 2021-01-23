    // Constructor of > SolutionA >  ProjectB > Calling Class
    public New() : base()
    {
    	AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
    }
    private Assembly AssemblyResolve(object sender, ResolveEventArgs e)
    {
    	Assembly ass = null;
    	if (e.Name.StartsWith("MyCommonLib,")) {
    		string path = Assembly.GetExecutingAssembly.Location;
    		path = IO.Path.GetDirectoryName(path);
    		path = IO.Path.Combine(path, "MyCommonLib.dll");
    		if (IO.File.Exists(path)) {
    			ass = Assembly.LoadFile(path);
    		}
    	}
    	return ass;
    }
