     public void accessHi3DRange(buffer)
        {
            double meanR = 0;
            uint sumR = 0;
            uint countR = 0;
            int numberOfScansR = buffer.Height;
            bitmapHeight = numberOfScansR;
    
            int subCompWidth = buffer.Components["Hi3D 1"].SubComponents["Range"].Format.Width;
            bitmapWidth = subCompWidth;
            ushort[,] data = buffer.Components["Hi3D 1"].SubComponents["Range"].GetRows<ushort>(0, numberOfScansR);
    
            for (int scan = 0; scan < numberOfScansR; scan++)
            {
    
                for (int col = 0; col < subCompWidth; col++)
                {
                    ushort val = data[scan, col];
                    if (val != 0)
                    {
                        sumR += val;
                        drawPix(col, scan, (int)val);
                        countR++;
                    }
                }
            }
        }
    
        private void drawPix(int x, int y, int rgb)
        {
            ((Bitmap)pictureBox1.Image).SetPixel(x, y, Color.FromArgb(rgb));
            return;
        }
