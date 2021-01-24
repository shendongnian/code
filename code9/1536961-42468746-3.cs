    public Image byteArrayToImage(byte[] byteArrayIn)
    {
         using (var ms = new MemoryStream(byteArrayIn))
         {
            return Image.FromStream(ms);
         }
    }
