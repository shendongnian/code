    public StartUp(IHostingEnvironment env)
    {
        ...
        Foo = new Foo();
    }
    public IFoo Foo { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        // you can now use `Foo` here, without injecting it.
    }
