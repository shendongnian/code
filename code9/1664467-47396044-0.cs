    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager rm;
        public MainWindowViewModel(IRegionManager manager)
        {
            this.rm = manager;
        }
        public void PopulateItemsControl()
        {
            var region = rm.Regions[RegionNames.itemsControlRegion];
            region.Add(new TextBlock { Text = "Item #1" });
        }
    }
