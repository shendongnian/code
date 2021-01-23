    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(@"g:\screenshot.png");
    BitmapImage bi = new BitmapImage();
    bi.BeginInit();
    MemoryStream ms = new MemoryStream();
    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    ms.Position = 0;            
            
    bi.StreamSource = ms;
    bi.EndInit();
    imgPhoto.Source = bi;
