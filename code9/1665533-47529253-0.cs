    public static IChildProcessHandle CreateChildProcessHandle() {
    	string assemblyPath = _sourcePath ?? Path.GetDirectoryName(Assembly.GetAssembly(typeof(WebBrowserInitializer)).Location);
    	Debug.Assert(assemblyPath != null, "assemblyPath != null");
    	var al = new ChildProcessFactory() { ClientExecutablePath = _sourcePath };
    	return al.Create(Path.Combine(assemblyPath, "MainApplication.WebBrowser.dll"), false, Environment.Is64BitProcess);
    }
