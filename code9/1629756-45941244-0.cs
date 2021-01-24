    private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        this.Dispatcher.BeginInvoke(new Action(() =>
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone()
            pboLive.Source = ImageSourceForBitmap(bitmap);
        }));
    }
