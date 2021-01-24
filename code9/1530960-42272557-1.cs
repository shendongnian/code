    private void StreamFromBitmapSource(BitmapSource writeBmp)
    {
        Stream bmp;
        using (bmp = new MemoryStream())
        {                    
            BitmapEncoder enc = new BmpBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(writeBmp));
            enc.Save(bmp);                                     
        }   
    }
