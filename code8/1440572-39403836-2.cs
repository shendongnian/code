    byte[] bytes = System.IO.File.ReadAllBytes(filename);
    System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
    using (var ms = new MemoryStream())
    {
          image.Save(ms, ImageFormat.Png); //fails here on GDI+ exception.
          //image.Save(ms, ImageFormat.Jpeg); //Jpeg Works somehow
    }
