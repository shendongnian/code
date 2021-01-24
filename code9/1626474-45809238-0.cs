    private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        var imageSource = ImageSourceForBitmap((System.Drawing.Bitmap)eventArgs.Frame);
        imageSource.Freeze();
        pboLive.Dispatcher.Invoke(() => pboLive.Source = imageSource);
    }
