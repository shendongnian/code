    protected override DependencyObject CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }
    protected override void InitializeShell()
    {
        var mainWindowViewModel = Container.Resolve<MainWindowViewModel>();
        Application.Current.MainWindow.DataContext = mainWindowViewModel;
        Application.Current.MainWindow.Show();
    }
    protected override void ConfigureContainer()
    {
        base.ConfigureContainer();
        Container.RegisterTypeForNavigation<TestUserControl>("firstUiDesign");
    }
