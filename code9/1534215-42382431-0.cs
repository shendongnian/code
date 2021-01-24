    internal static IFileProvider ResolveFileProvider(IHostingEnvironment hostingEnv)
    {
    	if (hostingEnv.WebRootFileProvider == null)
    	{
    		throw new InvalidOperationException("Missing FileProvider.");
    	}
    	return hostingEnv.WebRootFileProvider;
    }
