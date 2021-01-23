            int bmpHeight = pictureBox1.Image.Height;
            int bmpWidth = pictureBox1.Image.Width;
            Bitmap bmpFirst = (Bitmap)pictureBox1.Image.Clone();
            Graphics g = panel3.CreateGraphics();
            int[,] colorR = new int[bmpHeight * 8, bmpWidth * 8];
            int[,] colorG = new int[bmpHeight * 8, bmpWidth * 8];
            int[,] colorB = new int[bmpHeight * 8, bmpWidth * 8];
            for (int y = 0; y < bmpHeight; y++)
            {
                for (int x = 0; x < bmpWidth; x++)
                {
                    Color pixelColor = bmpFirst.GetPixel(x, y);
                    int dx = x * 8;
                    int dy = y * 8;
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            colorR[dx + j, dy + i] = pixelColor.R;
                            colorG[dx + j, dy + i] = pixelColor.G;
                            colorB[dx + j, dy + i] = pixelColor.B;
                        }
                    }
                    
                }
