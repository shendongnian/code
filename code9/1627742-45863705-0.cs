    protected override void OnStartup(object sender, StartupEventArgs e)
    {
        base.OnStartup(sender, e);
        DisplayRootViewFor<MainViewModel>();
        dynamic settings = new ExpandoObject();
        settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        settings.ResizeMode = ResizeMode.NoResize;
        var settingsVm = new SettingsViewModel(_container.GetInstance<IEventAggregator>());
        var result = _container.GetInstance<IWindowManager>()
            .ShowDialog(settingsVm, null, settings);
        settingsVm.Start();
    }
