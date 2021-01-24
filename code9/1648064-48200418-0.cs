    public void ConfigureServices(IServiceCollection services)
    {
        var adminAssembly = Assembly.Load(new AssemblyName("App"));
        services.AddMvc().AddApplicationPart(adminAssembly).AddRazorOptions(options =>
        {
            var previous = options.CompilationCallback;
            options.CompilationCallback = context =>
            {
                previous?.Invoke(context);
    
                var referenceAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                                        .Where(x => !x.IsDynamic)
                                        .Select(x => MetadataReference.CreateFromFile(x.Location))
                                        .ToList();
    
                                    //add dynamic
                                    var dynamicAssembly = typeof(DynamicAttribute).Assembly;
                                    referenceAssemblies.Add(MetadataReference.CreateFromFile(dynamicAssembly.Location));
    
                context.Compilation = context.Compilation.AddReferences(referenceAssemblies);
            };
        });
    
        services.Configure<RazorViewEngineOptions>(options =>
        {
            options.FileProviders.Add(new EmbeddedFileProvider(Assembly.Load("App")));
            options.FileProviders.Add(new PhysicalFileProvider(@"C:\Users\soheil\Documents\Visual Studio 2017\Projects\WebApplication5\App"));
        });
    }
