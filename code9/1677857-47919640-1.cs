    var sourceBitmap = new BitmapImage();
    using (var stream = new MemoryStream(ImageSource))
    {
        sourceBitmap.BeginInit();
        sourceBitmap.CacheOption = BitmapCacheOption.OnLoad;
        sourceBitmap.StreamSource = stream;
        sourceBitmap.EndInit();
    }
    // This should be another view model property that the Slider is bound to.
    // Only multiples of 90 degrees are valid values.
    var rotationAngle = 90d;
    var rotation = new RotateTransform(rotationAngle);
    var rotatedBitmap = new TransformedBitmap(sourceBitmap, rotation);
