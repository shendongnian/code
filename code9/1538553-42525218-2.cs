        private static async Task<WriteableBitmap> OpenWriteableBitmapFile(StorageFile file)
        {
            using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read))
            {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                WriteableBitmap image = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
                image.SetSource(stream);
                return image;
            }
        }
