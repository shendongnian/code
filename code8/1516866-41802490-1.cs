    public static void Main()
    {
        var readAllBytes = File.ReadAllBytes(@"SomeBitmap.bmp");
        var wr = new WeakReference(readAllBytes);
        var result = LoadImage(readAllBytes);
        readAllBytes = null;
        
        //result.StreamSource = null;
        
        result = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine($"IsAlive: {wr.IsAlive}");
        Console.ReadLine();
    }
    private static BitmapImage LoadImage(byte[] imageData)
    {
        if (imageData == null || imageData.Length == 0) return null;
        var image = new BitmapImage();
        using (var mem = new MemoryStream(imageData))
        {
            mem.Position = 0;
            image.BeginInit();
            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = null;
            image.StreamSource = mem;
            image.EndInit();
        }
        image.Freeze();
        return image;
    }
