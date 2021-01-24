     var listener = new DiagnosticListener("Microsoft.AspNetCore");
     var serviceCollection = new ServiceCollection();
     serviceCollection.AddMvcCore();
     var serviceProvider = serviceCollection
         .AddSingleton<IControllerActivator>(new ControllerActivator())
         .AddLogging()
         .AddSingleton<DiagnosticSource>(listener)
         .AddOptions()
         .AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>()
         .BuildServiceProvider();
...
     ApplicationBuilder builder = new ApplicationBuilder(serviceProvider);
     builder.UseMvc();
     return builder.Build();
