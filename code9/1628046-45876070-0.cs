    public class BrowseViewModelFactory
    {
        private IInjectedService _injectedService;
        public BrowseViewModelFactory(IInjectedService injectedService)
        {
            _injectedService = injectedService;
        }
        public BrowseViewModel CreateBrowseViewModel(int parentId)
        {
            return new BrowseViewModel(parentId, _injectedService);
        }
    }
