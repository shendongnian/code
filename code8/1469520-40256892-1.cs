    private ObservableCollection<Model> Collection = new ObservableCollection<Model>();
    
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        var files = await KnownFolders.PicturesLibrary.GetFilesAsync();
        foreach (var file in files)
        {
            var thumbnail = await file.GetThumbnailAsync(ThumbnailMode.PicturesView, 100);
            Collection.Add(new Model { Name = file.Name, Thumbnail = thumbnail });
        }
        gridView.ItemsSource = Collection;
    }
    
    public class Model
    {
        public StorageItemThumbnail Thumbnail { get; set; }
        public string Name { get; set; }
    }
