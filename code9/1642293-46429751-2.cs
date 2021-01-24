    public StartUp(IHostingEnvironment env)
    {
        ...
        FooInstance = new Foo();
    }
    public IFoo FooInstance { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        // you can now use `Foo` here, without injecting it.
    }
