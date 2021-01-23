           private void drawInkzone(MagickImage loadedImage, List<string>inkzoneAreaInformation, string filePath)
        {
            unitConversion converter = new unitConversion();
            List<double> inkZoneInfo = inkZoneListFill(inkzoneAreaInformation); //Larger image information
            float DPI = getImageDPI(filePath);
            double zoneAreaWidth_Pixels = converter.mmToPixel(inkZoneInfo.ElementAt(4), DPI); //Width and height for the larger image are in mm , converted them to pixel
            double zoneAreaHeight_Pixels = converter.mmToPixel(inkZoneInfo.ElementAt(5), DPI);//Formula (is: mm * imageDPI) / 25.4
            using (MagickImage image = new MagickImage(MagickColor.FromRgb(0, 0, 0), Convert.ToInt32(zoneAreaWidth_Pixels), Convert.ToInt32(zoneAreaHeight_Pixels)))
            {
                //first: defining the larger image, with a white background (must be transparent, but for now its okay)
                using (MagickImage original = loadedImage.Clone())
                {
                    //Cloned the original image (already passed as parameter)
                    image.Composite(loadedImage, Gravity.Center);
                    image.Write(@"C:\DI_PLOT\whatever.png");                  
                }
            }
