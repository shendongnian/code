                    BitmapImage bitmapCamera = new BitmapImage();
                    bitmapCamera.SetSource(streamCamera);
                    // Convert the camera bitap to a WriteableBitmap object, 
                    // which is often a more useful format.
                    int width = bitmapCamera.PixelWidth;
                    int height = bitmapCamera.PixelHeight;
                    WriteableBitmap wBitmap = new WriteableBitmap(width, height);
                    using (var stream = await capturedMedia.OpenAsync(FileAccessMode.Read))
                    {
                        wBitmap.SetSource(stream);
                    }
                    imgPreview.Source = wBitmap;
