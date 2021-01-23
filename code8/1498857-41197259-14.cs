    public class ViewModel 
    {
        public ObservableCollection<ImageItem> ImageCollection { get; }
            = new ObservableCollection<ImageItem>();
        public async Task LoadImages(StorageFolder folder)
        {
            var queryOptions = new QueryOptions(
                CommonFileQuery.DefaultQuery, new string[] { ".jpg", ".png", ".jpeg" });
            var files = await folder.CreateFileQueryWithOptions(queryOptions).GetFilesAsync();
            foreach (var file in files)
            {
                using (var stream = await file.OpenReadAsync())
                {
                    BitmapImage image = new BitmapImage();
                    await image.SetSourceAsync(stream);
                    ImageCollection.Add(new ImageItem
                    {
                        Image = image,
                        ImageText = file.Name
                    });
                }
            }
        }
    }
