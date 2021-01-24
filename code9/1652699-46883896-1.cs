    byte[] arr2 = Convert.FromBase64String(base64);
    using (MemoryStream ms2 = new MemoryStream(arr2))
    {
        System.Drawing.Bitmap bmp2 = new System.Drawing.Bitmap(ms2);
        bmp2.Save(filePath + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg); 
        ...
