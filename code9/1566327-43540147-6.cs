    private Bitmap BitmapImageToBitmap(BitmapImage bitmapImage)
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    BitmapEncoder enc = new BmpBitmapEncoder();
                    enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                    enc.Save(outStream);
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);
    
                    return new Bitmap(bitmap);
                }
            }
