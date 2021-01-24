    public void ImageToTIFF(string imagePath, string outputPath, string server, string folder, int sequenceNumber)
    {
        int page = 0;
        using (Aspose.Imaging.Image inputImage = Aspose.Imaging.Image.Load(imagePath))
        {
            page++;
            Aspose.Imaging.ImageOptions.TiffOptions tiffSaveOptions = new Aspose.Imaging.ImageOptions.TiffOptions(TiffExpectedFormat.Default);
            tiffSaveOptions.Compression = Aspose.Imaging.FileFormats.Tiff.Enums.TiffCompressions.CcittFax4;
            tiffSaveOptions.Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.MinIsBlack;
            tiffSaveOptions.BitsPerSample = new ushort[] { 1 };
            tiffSaveOptions.Palette = Aspose.Imaging.ColorPaletteHelper.CreateMonochrome();
            // Get the pixels of image by specifying the area as image boundary
            Aspose.Imaging.RasterImage image = inputImage as Aspose.Imaging.RasterImage;
            Aspose.Imaging.Color[] imageColors = image.LoadPixels(inputImage.Bounds);
            int power;
            for (int i = 0; i <= imageColors.Length - 1; i++)
            {
                try
                {
                    power = (int)imageColors[i].R + (int)imageColors[i].G + (int)imageColors[i].B;
                    if (power < 380)
                    {
                        imageColors[i] = Aspose.Imaging.Color.White;
                    }
                    else
                    {
                        imageColors[i] = Aspose.Imaging.Color.Black;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("i: {0}, imageColors[i].R: {1}, imageColors[i].G: {2}, imageColors[i].B: {3}", i, imageColors[i].R, imageColors[i].G, imageColors[i].B);
                    Console.WriteLine("Error: {0}", ex.Message);
                    imageColors[i] = Aspose.Imaging.Color.White;
                }
            }
            Aspose.Imaging.RasterImage imagePixels = inputImage as Aspose.Imaging.RasterImage;
            imagePixels.SavePixels(inputImage.Bounds, imageColors);
            inputImage.Save(outputPath + FileCreateTime(new FileInfo(imagePath)) + "_" + server + "_" + folder + "_" + sequenceNumber.ToString("D6") + "_" + page.ToString("D4") + ".tif", tiffSaveOptions);
        }
    }
