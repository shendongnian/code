    protected override void ConfigureViewModelLocator()
    {
        base.ConfigureViewModelLocator();
        Container.RegisterType<ViewAViewModel>(new ContainerControlledLifetimeManager()); //<--
        ViewModelLocationProvider.Register<ViewA, ViewABViewModel>();
        ViewModelLocationProvider.Register<ViewB, ViewABViewModel>();
    }
