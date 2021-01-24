        /// <summary>
        /// method that will create a source for your image object,
        /// and fill it with a specified array of pixels
        /// </summary>
        /// <param name="pixels">your array of pixels</param>
        /// <param name="image">your Image object</param>
        public void DrawImage(Int32[,] pixels, Image image)
        {
            int resX = pixels.GetUpperBound(0), resY = pixels.GetUpperBound(0);
            WriteableBitmap writableImg = new WriteableBitmap(resX, resY, 96, 96, PixelFormats.Bgr32, null);
            image.Source = writableImg;
            //lock the buffer
            writableImg.Lock();
            for (int i = 0; i< resX; i++)
            {
                for (int j = 0; j < resY; j++)
                {
                    IntPtr backbuffer = writableImg.BackBuffer;
                    //the buffer is a monodimensionnal array...
                    backbuffer += j * writableImg.BackBufferStride;
                    backbuffer += i * 4;
                    System.Runtime.InteropServices.Marshal.WriteInt32(backbuffer, pixels[i,j]);
                }
            }
            //specify the area to update
            writableImg.AddDirtyRect(new Int32Rect(0, 0, resX, resY));
            //release the buffer and show the image
            writableImg.Unlock();
        }
