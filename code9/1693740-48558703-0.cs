    public async Task RunAcquisition()
    {
        cam.BeginAcquisition();
        while (isLive)
        {
            var rawImage = await Task.Run(() => cam.GetNextImage());
            uiImage = ConvertRawToBitmapSource(rawImage);
        }
        cam.DeInit();
    }
