    using (Image image = System.Drawing.Image.FromStream(sourcePath))
    {
      Bitmap cpy = new Bitmap(image);
      Bitmap watermarkImage = new Bitmap(@"D:\Contact.png");
    
      using (Graphics gr = Graphics.FromImage(cpy))
      {
        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
        gr.CompositingQuality = CompositingQuality.HighQuality;
        gr.SmoothingMode = SmoothingMode.HighQuality;
        gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
    
        using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
        {
          int x = (cpy.Width / 2 - watermarkImage.Width / 2);
          int y = (cpy.Height / 2 - watermarkImage.Height / 2);
          watermarkBrush.TranslateTransform(x, y);
          gr.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
        }
      }
    
      var fullImagePath = string.Format("/Images/full/{0}", imageFileName);
      cpy.Save(Server.MapPath(fullImagePath), image.RawFormat);
    }
