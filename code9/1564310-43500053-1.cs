       public void loadImage(string fileName)
        {
          
            var dcm = EvilDICOM.Core.DICOMObject.Read(fileName);
            string photo = dcm.FindFirst(TagHelper.PHOTOMETRIC_INTERPRETATION).DData.ToString();
            ushort bitsAllocated = (ushort)dcm.FindFirst(TagHelper.BITS_ALLOCATED).DData;
            ushort highBit = (ushort)dcm.FindFirst(TagHelper.HIGH_BIT).DData;
            ushort bitsStored = (ushort)dcm.FindFirst(TagHelper.BITS_STORED).DData;
            double intercept =(double) dcm.FindFirst(TagHelper.RESCALE_INTERCEPT).DData;
            double slope = (double)dcm.FindFirst(TagHelper.RESCALE_SLOPE).DData;
            ushort rows = (ushort)dcm.FindFirst(TagHelper.ROWS).DData;
            ushort colums = (ushort)dcm.FindFirst(TagHelper.COLUMNS).DData;
            ushort pixelRepresentation = (ushort)dcm.FindFirst(TagHelper.PIXEL_REPRESENTATION).DData;
            List<byte> pixelData = (List<byte>)dcm.FindFirst(TagHelper.PIXEL_DATA).DData_;
            double window = (double)dcm.FindFirst(TagHelper.WINDOW_WIDTH).DData;
            double level = (double)dcm.FindFirst(TagHelper.WINDOW_CENTER).DData;
            int minVal = 0;
            int maxVal = 255;
            if (!photo.Contains("MONOCHROME"))//just works for gray images
                return;
            int index = 0;
            byte[] outPixelData = new byte[rows * colums * 4];//rgba
            ushort mask = (ushort)(ushort.MaxValue >> (bitsAllocated - bitsStored));
            double maxval = Math.Pow(2, bitsStored);
            for (int i = 0; i < pixelData.Count; i+=2)
            {
                ushort gray = (ushort)((ushort)(pixelData[i]) + (ushort)(pixelData[i + 1] << 8));
                double valgray = gray & mask;//remove not used bits
                if (pixelRepresentation == 1)// the last bit is the sign, apply a2 complement
                {
                    if (valgray > (maxval / 2))
                        valgray = (valgray - maxval);
                  
                }
                valgray = slope * valgray + intercept;//modality lut
                //This is  the window level algorithm
                double half = ((window - 1) / 2.0) - 0.5;
                if (valgray <= level - half)
                    valgray = 0;
                else if (valgray >= level + half)
                    valgray = 255;
                else
                    valgray = ((valgray - (level - 0.5)) / (window - 1) + 0.5) * 255;
                outPixelData[index] =(byte)valgray;
                outPixelData[index + 1] = (byte)valgray;
                outPixelData[index + 2] = (byte)valgray;
                outPixelData[index + 3] = 255;
                index += 4;
            }
            Image newimage = this.ImageFromRawBgraArray(outPixelData, colums, rows);
            pictureBox1.Image = newimage;
        }
        public Image ImageFromRawBgraArray(
           byte[] arr, int width, int height)
        {
            var output = new Bitmap(width, height);
            var rect = new Rectangle(0, 0, width, height);
            var bmpData = output.LockBits(rect,
                ImageLockMode.ReadWrite, output.PixelFormat);
            var ptr = bmpData.Scan0;
            Marshal.Copy(arr, 0, ptr, arr.Length);
            output.UnlockBits(bmpData);
            return output;
        }
