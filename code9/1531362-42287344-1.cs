    using Application.Shared;
    
    namespace Application.Modules
    {
        public class ModuleX : IModule
        {
    	private readonly IUnityContainer _container;
    	private readonly IRegionManager _region_manager;
    
    	public ModuleX (IUnityContainer container, IRegionManager region_manager)
            {
    		_container = container;
    		_region_manager = region_manager;
            }
            public override void Initialize()
            {
                _region_manager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(ToolViewX));
                _region_manager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(FinderViewX));
            }
        }
    }
