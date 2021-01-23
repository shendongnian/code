    public interface IDialogService
    {
        void ShowDialog(string uri);
    }
    public class DialogService : IDialogService
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        public DialogService(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }
        public void ShowDialog(string uri)
        {
            var dialog = _container.Resolve<DialogShell>();
            //use a scoped region just in case you can have multiple instances
            var scopedRegion = _regionManager.CreateRegionManager();
            //set the region manager of the dialog to the scoped region
            RegionManager.SetRegionManager(dialog, scopedRegion);
            //navigate to show the desired view in the dialog
            scopedRegion.RequestNavigate(KnownRegionNames.ContentRegion, uri);
            //show the dialog
            dialog.Show();
        }
    }
