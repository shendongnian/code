    public async static System.Threading.Tasks.Task<BitmapImage> ImageFromBytes(byte[] bytes)
    {
        var image = new BitmapImage();
        try
        {
            var stream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
            await stream.WriteAsync(bytes.AsBuffer());
            stream.Seek(0);
            await image.SetSourceAsync(stream);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    
        return image;
    }
