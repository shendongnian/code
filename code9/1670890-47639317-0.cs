    public Image byteArrayToImage(byte[] byteArrayIn)
    {
        try
        {
            using (var ms = new MemoryStream(byteArrayIn))
           {
              return Image.FromStream(ms);
            }
         }
        catch { }
        return returnImage;
    }
