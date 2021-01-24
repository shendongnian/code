    public async Task RunAcquisition()
    {
        cam.BeginAcquisition();
        while (isLive)
        {
            var rawImage = await cam.GetNextImageAsync();
            uiImage = ConvertRawToBitmapSource(rawImage);
        }
        cam.DeInit();
    }
