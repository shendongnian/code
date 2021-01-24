    protected override void ConfigureContainer()
    {
        base.ConfigureContainer();
        Container.RegisterInstance(new YourDbContext());
    }
