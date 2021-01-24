    public class ViewAViewModel: BindableBase
    {
        private readonly IRegionManager _regionManager;
        
        public ViewAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ButtonCommand= new DelegateCommand(ButtonClicked);
        }        
        private void ButtonClicked()
        {
            _regionManager.RequestNavigate("ContentRegion", "ViewB");
        }
    }
