    PhotoSearchThread = new Thread(() =>
    {
        Thread.CurrentThread.IsBackground = true;
        if (!string.IsNullOrWhiteSpace(searchWord))
        {
            string html = GetHtmlCode(searchWord);
            SearchedImagesUrls = GetUrls(html); 
            
            if (SearchedImagesUrls.Count > 0)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(SearchedImagesUrls[0]);
                image.EndInit();
                this.Dispatcher.Invoke(() =>
                {
                    SelectPhotoImage.Source = image; 
                });
            }
        }
    });
