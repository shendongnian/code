    var projectDir = GetProjectPath("", typeof(TStartup).GetTypeInfo().Assembly);
    _server = new TestServer(new WebHostBuilder()
        .UseEnvironment("Development")
        .UseContentRoot(projectDir)
        .UseConfiguration(new ConfigurationBuilder()
            .SetBasePath(projectDir)
            .AddJsonFile("appsettings.json")
            .Build()
        )
        .UseStartup<TestStartup>());
            
    
    /// Ref: https://stackoverflow.com/a/52136848/3634867
    /// <summary>
    /// Gets the full path to the target project that we wish to test
    /// </summary>
    /// <param name="projectRelativePath">
    /// The parent directory of the target project.
    /// e.g. src, samples, test, or test/Websites
    /// </param>
    /// <param name="startupAssembly">The target project's assembly.</param>
    /// <returns>The full path to the target project.</returns>
    private static string GetProjectPath(string projectRelativePath, Assembly startupAssembly)
    {
    	// Get name of the target project which we want to test
    	var projectName = startupAssembly.GetName().Name;
    
    	// Get currently executing test project path
    	var applicationBasePath = System.AppContext.BaseDirectory;
    
    	// Find the path to the target project
    	var directoryInfo = new DirectoryInfo(applicationBasePath);
    	do
    	{
    		directoryInfo = directoryInfo.Parent;
    
    		var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, projectRelativePath));
    		if (projectDirectoryInfo.Exists)
    		{
    			var projectFileInfo = new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName, $"{projectName}.csproj"));
    			if (projectFileInfo.Exists)
    			{
    				return Path.Combine(projectDirectoryInfo.FullName, projectName);
    			}
    		}
    	}
    	while (directoryInfo.Parent != null);
    
    	throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
    }
            
