    BarcodeWriterPixelData writer = new BarcodeWriterPixelData()
    {
        Format = BarcodeFormat.EAN_13
    };
    var pixelData = writer.Write(barcodeModel.BarcodeNumber);
    using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
    {
        using (var ms = new System.IO.MemoryStream())
        {
            var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            try
            {
                 // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image   
                System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
                    
            // PNG or JPEG or whatever you want
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            var base64str = Convert.ToBase64String(ms.ToArray());
        }
    }
