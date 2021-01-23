        Dispatcher.Invoke(new Action(() =>
        {
            lock (_frameCameralocker)
            {
                if(!isRunning)
                    return;
                var bitmapData = _frameCamera.LockBits(
                    new System.Drawing.Rectangle(0, 0, _frameCamera.Width, _frameCamera.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadOnly, _frameCamera.PixelFormat);
                if (_frameCamera.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                {
                    DeviceSource = System.Windows.Media.Imaging.BitmapSource.Create(
                                                        bitmapData.Width, bitmapData.Height, 96, 96, System.Windows.Media.PixelFormats.Gray8, null,
                                                        bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);
                }
                _frameCamera.UnlockBits(bitmapData);
                if (OnNewBitmapReady != null)
                    OnNewBitmapReady(this, null);
            }
        }));
