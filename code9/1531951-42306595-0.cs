    // get the current assembly from cache
    var currentAssembly = Assembly.GetEntryAssembly();
    
    // if current assembly is null
    if (currentAssembly == null)
    {
    	// get the current assembly from stack trace
    	currentAssembly = new StackTrace().GetFrames().Last().GetMethod().Module.Assembly;
    }
    
    // get the assemblies path (from returned assembly)
    assembliesPath = Path.GetDirectoryName(currentAssembly.Location);
