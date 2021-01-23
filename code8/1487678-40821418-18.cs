        private async void BlurThisUI(UIElement sourceElement, Image outputImage)
        {
            using (var stream = await sourceElement.RenderToRandomAccessStream())
            {
                var device = new CanvasDevice();
                var bitmap = await CanvasBitmap.LoadAsync(device, stream);
                var renderer = new CanvasRenderTarget(device,
                                                      bitmap.SizeInPixels.Width,
                                                      bitmap.SizeInPixels.Height,
                                                      bitmap.Dpi);
                using (var ds = renderer.CreateDrawingSession())
                {
                    var blur = new GaussianBlurEffect();
                    blur.BlurAmount = 5.0f;
                    blur.Source = bitmap;
                    ds.DrawImage(blur);
                }
                stream.Seek(0);
                await renderer.SaveAsync(stream, CanvasBitmapFileFormat.Png);
                BitmapImage image = new BitmapImage();
                image.SetSource(stream);
                outputImage.Source = image;
            }
        }
