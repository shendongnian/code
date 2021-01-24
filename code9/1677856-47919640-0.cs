    var sourceBitmap = new BitmapImage();
    using (var stream = new MemoryStream(ImageSource))
    {
        sourceBitmap.BeginInit();
        sourceBitmap.CacheOption = BitmapCacheOption.OnLoad;
        sourceBitmap.StreamSource = stream;
        sourceBitmap.EndInit();
    }
    var rotatedBitmap = new TransformBitmap(sourceBitmap, new RotateTransform(90));
