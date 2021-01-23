    public static async Task<StorageFile> ToFile(this RenderTargetBitmap renderTargetBitmap, string filename, StorageFolder folder = null) {
        if (folder == null) folder = ApplicationData.Current.TemporaryFolder;
        try {
            byte[] pixels = (await renderTargetBitmap.GetPixelsAsync()).ToArray();
            StorageFile outputFile = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            var bitmapEncodingMode = BitmapEncoder.PngEncoderId;
            using (var writeStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite)) {
                var encoder = await BitmapEncoder.CreateAsync(bitmapEncodingMode, writeStream);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, (uint)renderTargetBitmap.PixelWidth, (uint)renderTargetBitmap.PixelHeight, 96, 96, pixels);
                await encoder.FlushAsync();
            }
            return outputFile;
        } catch {
            return null;
        }
    }
