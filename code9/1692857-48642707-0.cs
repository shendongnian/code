      public void ConfigureServices(IServiceCollection services)
      {
        var asm = AssemblyLoadContext.Default.LoadFromAssemblyPath(@"D:\SomeTagHelpers\bin\Debug\netcoreapp2.0\SomeTagHelpers.dll");
        var part = new AssemblyPart(asm);
        var builder = services.AddMvc();
        builder.ConfigureApplicationPartManager(appPartManager => appPartManager.ApplicationParts.Add(part));    
    
        builder.Services.Configure((RazorViewEngineOptions options) =>
        {
          options.AdditionalCompilationReferences.Add(MetadataReference.CreateFromFile(asm.Location));
        });    
      }
