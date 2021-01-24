    public class AppBootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public AppBootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.RegisterPerRequest(typeof(AppViewModel), null, typeof(AppViewModel));
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<AppViewModel>();
        }
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
