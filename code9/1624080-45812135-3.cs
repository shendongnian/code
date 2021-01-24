    public class FileServerConfigurator
	{
		private readonly MiddlewareInjectorOptions middlewareInjectorOptions;
		public FileServerConfigurator(MiddlewareInjectorOptions middlewareInjectorOptions)
		{
			this.middlewareInjectorOptions = middlewareInjectorOptions;
		}
		public void SetPath(string requestPath, string physicalPath)
		{
			var fileProvider = new PhysicalFileProvider(physicalPath);
			
			middlewareInjectorOptions.InjectMiddleware(app =>
			{
				app.UseFileServer(new FileServerOptions
				{
					RequestPath = requestPath,
					FileProvider = fileProvider,
					EnableDirectoryBrowsing = true
				});
			});
		}
	}
