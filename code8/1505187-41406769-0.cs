    private async void Grid_DragOver(object sender, DragEventArgs e)  
    {
        e.DragUIOverride.Caption = "Some caption";
        e.DragUIOverride.IsCaptionVisible = true;
        e.DragUIOverride.IsContentVisible = true;
        e.DragUIOverride.IsGlyphVisible = true;
        e.AcceptedOperation = DataPackageOperation.Copy;
        //check the type of the file
        var items = await e.DataView.GetStorageItemsAsync();
        if (items.Any())
        {
           var storageFile = items[0] as StorageFile;
           if ( storageFile.FileType == ".jpg" )
           {
              e.DragUIOverride.SetContentFromBitmapImage(
                 new BitmapImage(new Uri("ms-appx:///Assets/jpgIcon.png")));
           }
           else if ( storageFile.FileType == "png" )
           {
              e.DragUIOverride.SetContentFromBitmapImage(
                 new BitmapImage(new Uri("ms-appx:///Assets/pngIcon.png")));
           }
           //...
           else
           {
              //for disallowed file types
              e.AcceptedOperation = DataPackageOperation.None;
              e.DragUIOverride.SetContentFromBitmapImage(
                 new BitmapImage(new Uri("ms-appx:///Assets/errorIcon.png")));
           }
        }
    }
