    public static async Task DoImageStuffAsync(Uri sourceUri, StorageFile outputFile)
        {
            using (CanvasBitmap bitmap = await CanvasBitmap.LoadAsync(CanvasDevice.GetSharedDevice(), sourceUri).AsTask().ConfigureAwait(false))
            using (CanvasRenderTarget target = new CanvasRenderTarget(CanvasDevice.GetSharedDevice(), (float)bitmap.Size.Width, (float)bitmap.Size.Height, bitmap.Dpi))
            {
                using (var ds = target.CreateDrawingSession())
                {
                    // todo : custom drawing code - this just draws the source image
                    ds.DrawImage(bitmap);
                }
                using (var outputStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite).AsTask().ConfigureAwait(false))
                {
                    await target.SaveAsync(outputStream, CanvasBitmapFileFormat.JpegXR).AsTask().ConfigureAwait(false);
                }
            }
        }
