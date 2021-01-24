    var serviceCollection = new ServiceCollection();
    serviceCollection.AddSingleton<ISomeService, SomeService>()
    serviceCollection.AddTransient<MyClass>();
    
    IServiceProvider provider = serviceCollection.BuildServiceProvider();
    
    MyClass instance = provider.GetService<MyClass>();
