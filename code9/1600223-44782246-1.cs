    internal class MainWindowViewModel : IMainWindowViewModel
    {
        public MainWindowViewModel()
        {
            //add the items...
            DirectoryItems.Add(new DirectoryItem() { DisplayName = "test", Children = new ObservableCollection<DirectoryItem>() { new DirectoryItem() { DisplayName = "child" } } });
            foreach(var item in DirectoryItems)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }
        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsSelected")
            {
                DirectoryItem selectedItem = sender as DirectoryItem;
                //set the DisplayText property
            }
        }
        public ObservableCollection<DirectoryItem> DirectoryItems { get; set; } = new ObservableCollection<DirectoryItem>();
        public string DisplayText { get; set; }
    }
