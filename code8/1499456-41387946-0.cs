    using (MagickImage magickBaseImg = new MagickImage(baseImageFileName))
    using (MagickImage magickTargetImg = new MagickImage(targetImageFileName))
    {
      using (var diffImg = new MagickImage())
      {
        magickBaseImg.Compare(magickTargetImg, ErrorMetric.RootMeanSquared, diffImg, Channels.Red);
        DateTime currentTime = DateTime.Now;
        string differencesImageSavingPath = @"C:\test\DiffImage" + currentTime.ToString("ddMMyyyyHHmm") + ".bmp";
        diffImg.Save(differencesImageSavingPath);
        differencesImageFileName = differencesImageSavingPath;
        DiffrenceImage.Source = new BitmapImage(new Uri(differencesImageFileName));
      }
    }
