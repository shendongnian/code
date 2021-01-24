	public override CacheDependency GetCacheDependency(string virtualPath,  virtualPathDependencies, DateTime utcStart)
	{
		string embedded = _GetEmbeddedPath(virtualPath);
		// not embedded? fall back
		if (string.IsNullOrEmpty(embedded))
			return base.GetCacheDependency(virtualPath,
				virtualPathDependencies, utcStart);
		// there is no cache dependency for embedded resources
		return null;
	}
	public override bool FileExists(string virtualPath)
	{
		string embedded = _GetEmbeddedPath(virtualPath);
		// You can override the embed by placing a real file at the virtual path...
		return base.FileExists(virtualPath) || !string.IsNullOrEmpty(embedded);
	}
	public override VirtualFile GetFile(string virtualPath)
	{
		// You can override the embed by placing a real file at the virtual path...
		if (base.FileExists(virtualPath))
			return base.GetFile(virtualPath);
		string embedded = _GetEmbeddedPath(virtualPath);
		if (string.IsNullOrEmpty(embedded))
			return null;
		return new EmbeddedVirtualFile(virtualPath, GetType().Assembly
			.GetManifestResourceStream(embedded));
	}
	private string _GetEmbeddedPath(string path)
	{
		if (path.StartsWith("~/"))
			path = path.Substring(1);
		path = path.Replace(BookingEngine.Route, "/");
		//path = path.ToLowerInvariant();
		path = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + path.Replace('/', '.');
		// this makes sure the "virtual path" exists as an embedded resource
		return GetType().Assembly.GetManifestResourceNames()
			.Where(o => o == path).FirstOrDefault();
	}
