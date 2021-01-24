    public static byte[] ConvertToBytes(BitmapImage bitmapImage)
    {
        using (var ms = new MemoryStream())
        {
            var btmMap = new WriteableBitmap(bitmapImage.PixelWidth, bitmapImage.PixelHeight);
            btmMap.SaveJpeg(ms, bitmapImage.PixelWidth, bitmapImage.PixelHeight, 0, 100);
            return ms.ToArray();
        }
    }
    var serializer = new DataContractSerializer(typeof(byte[]));
        using (var stream = await ApplicationData.Current.LocalCacheFolder.OpenStreamForWriteAsync(fileName, CreationCollisionOption.ReplaceExisting)) {
            serializer.WriteObject(stream, ConvertToBytes(collection));
        }
