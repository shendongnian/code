    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void InitializeShell()
        {
            RegisterTypeIfMissing(typeof(IEventAggregator), typeof(EventAggregator), true);
            Application.Current.MainWindow.DataContext = new MainWindowViewModel(Container.Resolve<IEventAggregator>());
            Application.Current.MainWindow.Show();
        }
    }
