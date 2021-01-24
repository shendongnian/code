	private static string ContentPath
	{
		get
		{
			var path = PlatformServices.Default.Application.ApplicationBasePath;
			var contentPath = Path.GetFullPath(Path.Combine(path, $@"..\..\..\..\{nameof(src)}"));
			return contentPath;
		}
	}
.
	var builder = new WebHostBuilder()
		.UseContentRoot(ContentPath)
		.ConfigureLogging(factory =>
		{
			factory.AddConsole();
		})
		.UseStartup<Startup>()
		.ConfigureServices(services =>
		 {
			 services.Configure((RazorViewEngineOptions options) =>
			 {
				 var previous = options.CompilationCallback;
				 options.CompilationCallback = (context) =>
				 {
					 previous?.Invoke(context);
					 var assembly = typeof(Startup).GetTypeInfo().Assembly;
					 var assemblies = assembly.GetReferencedAssemblies().Select(x => MetadataReference.CreateFromFile(Assembly.Load(x).Location))
					 .ToList();
					 assemblies.Add(MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("mscorlib")).Location));
					 assemblies.Add(MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("System.Private.Corelib")).Location));
					 assemblies.Add(MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("Microsoft.AspNetCore.Razor")).Location));
					 context.Compilation = context.Compilation.AddReferences(assemblies);
				 };
			 });
		 });
		_server = new TestServer(builder);
