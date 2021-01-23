    int WriteBitmapFile(string filename, int width, int height, byte[] imageData)
        {
            byte[] newData = new byte[imageData.Length];
            for(int x = 0; x < imageData.Length; x+= 4)
            {
                byte[] pixel = new byte[4];
                Array.Copy(imageData, x, pixel, 0, 4);
                byte r = pixel[0];
                byte g = pixel[1];
                byte b = pixel[2];
                byte a = pixel[3];
                byte[] newPixel = new byte[] { b, g, r, a };
                Array.Copy(newPixel, 0, newData, x, 4);
            }
            imageData = newData;
            using (var stream = new MemoryStream(imageData))
            using (var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0,
                                                                bmp.Width,
                                                                bmp.Height),
                                                  ImageLockMode.WriteOnly,
                                                  bmp.PixelFormat);
                IntPtr pNative = bmpData.Scan0;
                Marshal.Copy(imageData, 0, pNative, imageData.Length);
                bmp.UnlockBits(bmpData);
                bmp.Save(filename);
            }
            return 1;
        }
