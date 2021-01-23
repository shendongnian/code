    private async Task<ImageSource> ProcessImageAsync(StorageFile ImageFile)
        {
            if (ImageFile == null)
                throw new ArgumentNullException("ImageFile cannot be null.");
            //The new size of processed image.
            const int side = 100;
            //Initialize bitmap transformations to be applied to the image.
            var transform = new BitmapTransform() { ScaledWidth = side, ScaledHeight = side, InterpolationMode = BitmapInterpolationMode.Cubic };
            //Get image pixels.
            var stream = await ImageFile.OpenStreamForReadAsync();
            var decoder = await BitmapDecoder.CreateAsync(stream.AsRandomAccessStream());
            var pixelData = await decoder.GetPixelDataAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied, transform, ExifOrientationMode.RespectExifOrientation, ColorManagementMode.ColorManageToSRgb);
            var pixels = pixelData.DetachPixelData();
            //Initialize writable bitmap.
            var wBitmap = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
            await wBitmap.SetSourceAsync(stream.AsRandomAccessStream());
            //Create a software bitmap from the writable bitmap's pixel buffer.
            var sBitmap = SoftwareBitmap.CreateCopyFromBuffer(wBitmap.PixelBuffer, BitmapPixelFormat.Bgra8, side, side, BitmapAlphaMode.Premultiplied);
            //Create software bitmap source.
            var sBitmapSource = new SoftwareBitmapSource();
            await sBitmapSource.SetBitmapAsync(sBitmap);
            return sBitmapSource;
        }
