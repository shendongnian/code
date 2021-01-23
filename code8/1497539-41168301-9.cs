    public class PicturesViewModel
    {
        public ObservableCollection<ImageSource> MyImages { get; }
            = new ObservableCollection<ImageSource>();
        public async Task GetImages()
        {
            var files = await KnownFolders.PicturesLibrary.GetFilesAsync();
            foreach (var file in files)
            {
                using (var stream = await file.OpenReadAsync())
                {
                    BitmapImage image = new BitmapImage();
                    await image.SetSourceAsync(stream);
                    MyImages.Add(image);
                }
            }
        }
    }
