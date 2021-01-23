        private async Task<WriteableBitmap> GetSignatureBitmapCropped()
        {
            try
            {
                var canvasStrokes = cvsSignature.InkPresenter.StrokeContainer.GetStrokes();
                if (canvasStrokes.Count > 0)
                {
                    var bounds = cvsSignature.InkPresenter.StrokeContainer.BoundingRect;
                    var xOffset = (uint)Math.Round(bounds.X);
                    var yOffset = (uint)Math.Round(bounds.Y);
                    var pixelWidth = (int)Math.Round(bounds.Width);
                    var pixelHeight = (int)Math.Round(bounds.Height);
                    using (var memStream = new InMemoryRandomAccessStream())
                    {
                        await cvsSignature.InkPresenter.StrokeContainer.SaveAsync(memStream);
                        var decoder = await BitmapDecoder.CreateAsync(memStream);
                        var transform = new BitmapTransform();
                        var newBounds = new BitmapBounds();
                        newBounds.X = 0;
                        newBounds.Y = 0;
                        newBounds.Width = (uint)pixelWidth;
                        newBounds.Height = (uint)pixelHeight;
                        transform.Bounds = newBounds;
                        var pdp = await decoder.GetPixelDataAsync(
                            BitmapPixelFormat.Bgra8,
                            BitmapAlphaMode.Straight,
                            transform,
                            ExifOrientationMode.IgnoreExifOrientation,
                            ColorManagementMode.DoNotColorManage);
                        var pixels = pdp.DetachPixelData();
                        var cropBmp = new WriteableBitmap(pixelWidth, pixelHeight);
                        using (var stream = cropBmp.PixelBuffer.AsStream())
                        {
                            await stream.WriteAsync(pixels, 0, pixels.Length);
                        }
                        return cropBmp;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
