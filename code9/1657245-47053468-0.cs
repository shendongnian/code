    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void InitializeShell()
        {
            Application.Current.MainWindow.DataContext = new MainWindowViewModel();
            Application.Current.MainWindow.Show();
        }
        protected override void InitializeModules()
        {
            base.InitializeModules();
            var eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<PubSubEvent<string>>().Publish("ModulesLoaded");
        }
    }
