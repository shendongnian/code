    private static BitmapImage LoadImage(byte[] imageData)
    {
        if (imageData == null || imageData.Length == 0) return null;
        var image = new BitmapImage();
        using (var mem = new MemoryStream(imageData))
        {
            mem.Position = 0;
            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            image.UriSource = null;
            image.StreamSource = mem;
        }
        return image;
    }
