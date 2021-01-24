    protected override void ConfigureViewModelLocator()
    {
        base.ConfigureViewModelLocator();
        ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
        ViewModelLocationProvider.Register<SignInView, SignInViewModel>();
        ViewModelLocationProvider.Register<ConfigurationView, ConfigurationViewModel>();
        Container.RegisterInstance(new SignInView());
        Container.RegisterInstance(new ConfigurationView());
    }
    protected override DependencyObject CreateShell()
    {
        IRegionManager _regionManager = Container.Resolve<IRegionManager>();
        IRegion _region = _regionManager.Regions[RegionNames.MainRegion];
        _region.Add(Container.Resolve<SignInView>());
        _region.Add(Container.Resolve<ConfigurationView>());
        return Container.Resolve<MainWindow>();
    }
    protected override void InitializeShell()
    {
        Application.Current.MainWindow.Show();
    }
