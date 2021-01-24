    public override void Initialize()
    {
        (...)
        IocManager.Register<IHostingEnvironment, MockHostingEnvironment>(DependencyLifeStyle.Singleton);
    }
