    public class ViewModel 
    {
        ObservableCollection<ImageItem> ImageCollection { get; }
            = new ObservableCollection<ImageItem>();
        public async Task LoadImages(StorageFolder folder)
        {
            ...
        }
    }
