    var serviceCollection = new ServiceCollection();
    serviceCollection.AddDataProtection()
        .SetApplicationName("my-app")
        .PersistKeysToFileSystem(new DirectoryInfo(@"G:\tmp\so\keys"));
    var services = serviceCollection.BuildServiceProvider();
    var provider = services.GetService<IDataProtectionProvider>();
    var protector = provider.CreateProtector("some_purpose");                
    Console.WriteLine(Convert.ToBase64String(protector.Protect(Encoding.UTF8.GetBytes("hello world"))));
