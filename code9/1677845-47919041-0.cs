        private static void MySaveBMP(byte[] buffer, int width, int height)
        {
            Bitmap b = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Rectangle BoundsRect = new Rectangle(0, 0, width, height);
            BitmapData bmpData = b.LockBits(BoundsRect,
                                            ImageLockMode.WriteOnly,
                                            b.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            // add back dummy bytes between lines, make each line be a multiple of 4 bytes
            int skipByte = bmpData.Stride - width*3;
            byte[] newBuff = new byte[buffer.Length + skipByte*height];
            for (int j = 0; j < height; j++)
            {
                Buffer.BlockCopy(buffer, j * width * 3, newBuff, j * (width * 3 + skipByte), width * 3);
            }
            // fill in rgbValues
            Marshal.Copy(newBuff, 0, ptr, newBuff.Length);
            b.UnlockBits(bmpData);
            b.Save(@"D:\myPic.bmp", ImageFormat.Bmp);        
        }
