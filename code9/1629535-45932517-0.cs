     public async static System.Threading.Tasks.Task<BitmapImage> ImageFromBytes(byte[] bytes)
        {
            BitmapImage image = null;
            try
            {
                image = new BitmapImage();
                Windows.Storage.Streams.InMemoryRandomAccessStream stream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
                await stream.WriteAsync(bytes.AsBuffer());
                stream.Seek(0);
                image.SetSource(stream);
            }
    
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
    
            return image;
        }
