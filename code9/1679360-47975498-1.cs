        // Draw white method
        public void draw_white(buffer)
        {
            int numberOfScansR = buffer.Height;
            bitmapHeight = numberOfScansR;
            int subCompWidth = buffer.Components["R"].Format.Width;
            bitmapWidth = subCompWidth;
            for (int scan = 0; scan < numberOfScansR; scan++)
            {
                for (int col = 0; col < subCompWidth; col++)
                {
                    // Draw the entire picturebox white color
                    drawPix(col, scan, (int)255, (int)255, (int)255);
                }
            }
        }
        // R Mode Tab
        private void RModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        // Timer for R mode
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Grab buffer from camera
            camera.grab(out buffer);
            draw_white(buffer);
            pictureBox.Invalidate();
            pictureBox.Update();
            accessRMode(buffer); 
            pictureBox.Invalidate();
            pictureBox.Update();
            // Release buffer       
            camera.Release();
        }
        // For accessing R Mode
        private void accessRMode(buffer)
        {
            int numberOfScansR = buffer.Height;
            bitmapHeight = numberOfScansR;
            // Loop through all scans in the buffer.
            int CompWidth = buffer.Components["R mode"].Format.Width;
            bitmapWidth = CompWidth;
            // Get pointer to beginning of scan number 'scan' of R mode
            ushort[,] data = buffer.Components["R mode"].GetRows<ushort>(0, 
            numberOfScansR);
            for (int scan = 0; scan < numberOfScansR; scan++)
            {
                // Loop through all elements in each scan.
                for (int col = 0; col < CompWidth; col++)
                {
                    ushort val = data[scan, col];
                    if (val != 0)
                    {
                        sumR += val;
                        val = (ushort)(val / 257);
                        drawpix(col, scan, (int)val, (int)val, (int)val);
                        countR++;
                    }
                }
            }
        }
        // Draw pixel method
        private void drawPix(int x, int y, int r, int g, int b)
        {
            ((Bitmap)pictureBox.Image).SetPixel(x, y, Color.FromArgb(r, g, b));
            return;
        }
