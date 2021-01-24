      public void ConfigureServices(IServiceCollection services)
            {
                var assembly = typeof(Startup).GetTypeInfo().Assembly;
                var assemblies = assembly.GetReferencedAssemblies().Select(x => MetadataReference.CreateFromFile(Assembly.Load(x).Location))
                .ToList();
                assemblies.Add(MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("System.Private.Corelib")).Location));
                services.AddMvc();
            }
