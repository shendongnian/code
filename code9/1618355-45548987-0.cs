    private void ProcessNewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        Bitmap frame = (Bitmap) eventArgs.Frame.Clone();
        if (detector.ProcessFrame(frame) > 0.02)
        {
            // ring alarm or do somethng else
        }
    }
