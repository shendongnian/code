    StorageFile imagefile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/caffe2.jpg"));
    int width;
    int height;
    byte[] Inptrbuffer;
    using (IRandomAccessStream stream = await imagefile.OpenAsync(FileAccessMode.Read))
    {
        SoftwareBitmap softwareBitmap;
        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
        softwareBitmap = await decoder.GetSoftwareBitmapAsync();
        width = softwareBitmap.PixelWidth;
        height = softwareBitmap.PixelHeight;
        Windows.Graphics.Imaging.PixelDataProvider pixelData = await decoder.GetPixelDataAsync();
        Inptrbuffer = pixelData.DetachPixelData(); 
    }
    WriteableBitmap newfrompixel=new WriteableBitmap(width,height);
    using (Stream stream = newfrompixel.PixelBuffer.AsStream())
    {
        await stream.WriteAsync(Inptrbuffer, 0, Inptrbuffer.Length);
    } 
    Windows.UI.Xaml.Controls.Image image = new Windows.UI.Xaml.Controls.Image(); 
    image.Source = newfrompixel; 
    stackPanel.Children.Add(image);
