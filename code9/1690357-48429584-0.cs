    services.AddSingleton<IAnotherObject, AnotherObject>();
    services.AddSingleton<ISecurityManager, SecurityManager>();
    services.AddSingleton<ITestObject, TestObject>((provider) => 
    {
        var user = provider.GetService<ISecurityManager>().GetCurrentUserName();
        return new TestObject(provider.GetService<IAnotherObject>(), user);
    });
