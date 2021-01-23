       List<Images> ImageCollection;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageCollection = new List<Images>();
            // pick a folder
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.FileTypeFilter.Add(".jpg");
            var folder = await folderPicker.PickSingleFolderAsync();
            var filesList = await folder.CreateFileQueryWithOptions(new QueryOptions(CommonFileQuery.DefaultQuery, new string[] { ".jpg", ".png", ".jpeg" })).GetFilesAsync();
            for (int i = 0; i < filesList.Count; i++)
            {
                StorageFile imagefile = filesList[i];
                BitmapImage bitmapimage = new BitmapImage();
                using (IRandomAccessStream stream = await imagefile.OpenAsync(FileAccessMode.Read))
                {
                    bitmapimage.SetSource(stream);
                }
                ImageCollection.Add(new Images()
                {
                    ImageURL = bitmapimage,
                    ImageText = filesList[i].Name
                });
            }
            AdaptiveGV.ItemsSource = ImageCollection;
        }
    }
    public class Images
    {
        public ImageSource ImageURL { get; set; }
        public string ImageText { get; set; }
    }
