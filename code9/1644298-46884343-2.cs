    [Dependency]
    public ISomeDependency SomeDepenency { get; set; }
    public Customer()
    {
        Ioc.BuildUp(this);
    }
