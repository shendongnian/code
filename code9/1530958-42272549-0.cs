    private Stream StreamFromBitmapSource(BitmapSource writeBmp)
    {
        Stream bmp= new MemoryStream();
        using (enc = new BmpBitmapEncoder())
        {                    
            enc.Frames.Add(BitmapFrame.Create(writeBmp));
            enc.Save(bmp);                                     
        }
    
       return bmp;
    }
