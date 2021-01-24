        BitmapImage btm = new BitmapImage();
        using (MemoryStream ms = new MemoryStream(image_link))
        {
            ms.Position = 0;
            btm.BeginInit();
            btm.StreamSource = ms;
            btm.CacheOption = BitmapCacheOption.OnLoad;
            btm.EndInit();
        }
        btm.Freeze();
        brush = btm;
