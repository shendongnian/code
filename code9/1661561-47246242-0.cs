    public void UpdateUI() // C# naming conventions
    {
        reader.Open(RTSPAddress);
        while (true)
        {
            Bitmap previousFrame = pictureRTSP.BackgroundImage;
            Bitmap currentFrame = reader.ReadVideoFrame();
            pictureRTSP.BackgroundImage = currentFrame;
            if (previousFrame != null)
                previousFrame.Dispose();
        }
    }
