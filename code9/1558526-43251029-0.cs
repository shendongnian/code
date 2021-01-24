    public class HelloBootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new SimpleContainer();
        public HelloBootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            DisplayRootViewFor<MainViewModel>();
        }
        protected override void Configure()
        {
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.RegisterPerRequest(typeof(MainViewModel), null, typeof(MainViewModel));
        }
        protected override object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
