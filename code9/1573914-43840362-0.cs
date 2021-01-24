    StorageFile imagefile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/caffe1.jpg"));
    WriteableBitmap writeableimage;
    using (IRandomAccessStream stream = await imagefile.OpenAsync(FileAccessMode.Read))
    {
        SoftwareBitmap softwareBitmap;
        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
        softwareBitmap = await decoder.GetSoftwareBitmapAsync();
        writeableimage = new WriteableBitmap(softwareBitmap.PixelWidth, softwareBitmap.PixelHeight);
        writeableimage.SetSource(stream);
    }
    Windows.UI.Xaml.Controls.Image image = new Windows.UI.Xaml.Controls.Image();
    image.Source = writeableimage;
    stackPanel.Children.Add(image);
