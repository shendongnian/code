    public class ModuleAModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;
        public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }
        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ViewB>();
        }
    }
