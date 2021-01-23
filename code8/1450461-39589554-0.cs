    public byte[] imageToByteArray(Image imageIn, ImageFormat format)
    {
        using(var ms = new MemoryStream())
        {
            imageIn.Save(ms,format);
            return ms.ToArray();
        }
     }
  
