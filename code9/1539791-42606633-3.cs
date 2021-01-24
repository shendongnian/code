      // load the file as 24bpp RGB
      using (var bmp = LoadForFiltering(@"C:\temp\Testing-Image3.tif"))
      {
          var filter = new Median();
          // run the filter 
          filter.ApplyInPlace(bmp);
          // save the file back (here, I used png as the output format)
          bmp.Save(@"C:\temp\Testing-Image3.png");
      }
    
    
      private static Bitmap LoadForFiltering(string filePath)
      {
          var bmp = (Bitmap)Bitmap.FromFile(filePath);
          if (bmp.PixelFormat == PixelFormat.Format24bppRgb)
              return bmp;
    
          try
          {
              // from AForge's sample code
              if (bmp.PixelFormat == PixelFormat.Format16bppGrayScale || Bitmap.GetPixelFormatSize(bmp.PixelFormat) > 32)
                  throw new NotSupportedException("Unsupported image format");
    
              return AForge.Imaging.Image.Clone(bmp, PixelFormat.Format24bppRgb);
          }
          finally
          {
              bmp.Dispose();
          }
      }
