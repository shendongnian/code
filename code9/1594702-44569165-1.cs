    protected override void ConfigureViewModelLocator()
    {
        base.ConfigureViewModelLocator();
        ViewModelLocationProvider.Register<SignInView, SignInViewModel>();
        ViewModelLocationProvider.Register<ConfigurationView, ConfigurationViewModel>();
        Container.RegisterInstance(new SignInView());
        Container.RegisterInstance(new ConfigurationView());
    }
    protected override DependencyObject CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }
    protected override void InitializeShell()
    {
        IRegionManager _regionManager = Container.Resolve<IRegionManager>();
        IRegion _region = _regionManager.Regions[RegionNames.MainRegion];
        _region.Add(Container.Resolve<SignInView>());
        _region.Add(Container.Resolve<ConfigurationView>());
        var mainWindowViewModel = Container.Resolve<MainWindowViewModel>();
        Application.Current.MainWindow.DataContext = mainWindowViewModel;
        Application.Current.MainWindow.Show();
    }
