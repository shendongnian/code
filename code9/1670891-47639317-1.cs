    public Image byteArrayToImage(byte[] byteArrayIn)
    {
        try
        {
            using (var ms = new MemoryStream(byteArrayIn))
           {
              return Image.FromStream(ms);
            }
         }
        catch(Exception ex)
        { console.WriteLine(ex.Tostring()); }
        return returnImage;
    }
