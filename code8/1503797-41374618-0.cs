    private void drawInkzone(MagickImage loadedImage, List<string> inkzoneAreaInformation, string filePath)
    {
      unitConversion converter = new unitConversion();
      List<double> inkZoneInfo = inkZoneListFill(inkzoneAreaInformation);
      float DPI = getImageDPI(filePath);
      double zoneAreaWidth_Pixels = converter.mmToPixel(inkZoneInfo.ElementAt(4), DPI);
      double zoneAreaHeight_Pixels = converter.mmToPixel(inkZoneInfo.ElementAt(5), DPI);
      using (MagickImage image = loadedImage.Clone())
      {
        MagickColor background = MagickColors.Black;
        int width = (int)zoneAreaWidth_Pixels;
        int height = (int)zoneAreaHeight_Pixels;
        image.Extent(width, height, Gravity.Center, background);
        image.Write(@"C:\DI_PLOT\whatever.png");
      }
    }
