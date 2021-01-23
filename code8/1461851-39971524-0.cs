    // Factory --------------------------------------------------------
    public interface IDependencyFactory
    {
        IService GetService();
    }
    public class DependencyFactory : IDependencyFactory
    {
        private readonly IUnityContainer _container;
        public DependencyFactory(IUnityContainer container)
        {
            _container = container;
        }
        public IService GetService()
        {
            return _container.Resolve<IService>();
        }
    }
    // PubSubEvent ------------------------------------------------------
    public class AllModulesLoaded : PubSubEvent
    {
    }
    // Bootstrapper -----------------------------------------------------
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
        protected override void InitializeModules()
        {
            base.InitializeModules();
            // Publishing event to tell subscribers that the modules are loaded
            var eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator?.GetEvent<AllModulesLoaded>().Publish();
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            // ...
            Container.RegisterType<IDependencyFactory, DependencyFactory>();
        }
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
    // ViewModel ---------------------------------------------------------
    public class MainWindowViewModel : BindableBase
    {
        private IService _service;
        private readonly IEventAggregator _eventAggregator;
        private readonly IDependencyFactory _dependencyFactory;
        public MainWindowViewModel(IEventAggregator eventAggregator, IDependencyFactory dependencyFactory)
        {
            _eventAggregator = eventAggregator;
            _dependencyFactory = dependencyFactory;
            _eventAggregator.GetEvent<AllModulesLoaded>().Subscribe(OnAllModulesLoaded);
        }
        private void OnAllModulesLoaded()
        {
            var service = _dependencyFactory.GetService();
            if (service != null)
                _service = service ;
            _eventAggregator.GetEvent<AllModulesLoaded>().Unsubscribe(OnAllModulesLoaded);
        }
    }
