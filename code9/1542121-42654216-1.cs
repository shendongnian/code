    public class ProjectSettingsViewModel
    {
        private readonly IRegionManager _regionManager;
        public ProjectSettingsViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CloseTabCommand = new DelegateCommand<object>(OnExecuteCloseCommand);
        }
        private void OnExecuteCloseCommand(object tabItem)
        {
            _regionManager.Regions["MainViewTabRegion"].Remove(tabItem);
        }
        public DelegateCommand<object> CloseTabCommand { get; }
    }
