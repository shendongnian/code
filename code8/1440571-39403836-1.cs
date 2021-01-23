    var path = @"C:\Project\images\logo.png";
    using (Image image = Image.FromFile(path))
    {
          using (var ms = new MemoryStream())
          {
                image.Save(ms, ImageFormat.Png); //fails here on GDI+ exception.
                //image.Save(ms, ImageFormat.Jpeg); //Jpeg Works somehow
          }
    }
