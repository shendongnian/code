    using (var img1 = new MagickImage(@"C:\test\Image1.jpg"))
    {
      using (var img2 = new MagickImage(@"C:\test\Image2.jpg"))
      {
        using (var imgDiff = new MagickImage())
        {
          double diff = img1.Compare(img2, new ErrorMetric(), imgDiff);
          imgDiff.Write(@"C:\test\Diff-Image1-Image2.jpg");
        }
      }
    }
