    using (var imageMagick = new MagickImage(filePath))
    {
      imageMagick.Transparent(MagickColor.FromRgb(0,0,0));
      imageMagick.FilterType = FilterType.Quadratic;
      imageMagick.Resize(newWidth, newHeight);
      imageMagick.ColorType = ColorType.Bilevel;
      imageMagick.Format = MagickFormat.Png8;
      imageMagick.Write(targetPath);
    }
