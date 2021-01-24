        var folder = Package.Current.InstalledLocation;
        var file = await folder.GetFileAsync("TestImage.png");
        var bitmapImage1 = new BitmapImage();
        _image.Source = bitmapImage1;
        using (var stream = await file.OpenAsync(FileAccessMode.Read))
        {
            await bitmapImage1.SetSourceAsync(stream);
        }
