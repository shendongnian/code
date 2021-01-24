    public partial class App
    {
        protected override void OnInitialized()
        {
            var ea = Container.Resolve<IEventAggregator>();
            ea.GetEvent<SettingsChangedEvent>().Subscribe(OnSettingsChangedEvent);
            // navigate
        }
        private void OnSettingsChangedEvent()
        {
            var ea = Container.Resolve<IEventAggregator>();
            // prevent a memory leak
            ea.GetEvent<SettingsChangedEvent>().Unsubscribe(OnSettingsChangedEvent);
            // If you need platform specific types be sure to register either the 
            // IPlatformInitializer or some similar helper
            var platformInitializer = Container.Resolve<IPlatformInitializer>();
            ModuleCatalog = CreateModuleCatalog();
            ConfigureModuleCatalog();
            Container = CreateContainer();
            ConfigureContainer();
            // This would be your original RegisterTypes, so this assumes you 
            // look at your settings when initially registering types.
            RegisterTypes();
            // See notes above
            platformInitializer.RegisterTypes(Container);
            NavigationService = CreateNavigationService();
            InitializeModules();
            // Your container is now reset. 
            var ea = Container.Resolve<IEventAggregator>();
            ea.GetEvent<SettingsChangedEvent>().Subscribe(OnSettingsChangedEvent>()
        }
    }
