    private void button4_Click(object sender, EventArgs e       )
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "*.bmp|*.bmp|*.*|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int bmpHeight = pictureBox1.Image.Height;
            int bmpWidth = pictureBox1.Image.Width;
            Bitmap bmpFirst = (Bitmap)pictureBox1.Image.Clone();
            Graphics g = panel1.CreateGraphics();
            int[,] colorR = new int[bmpHeight*2 , bmpWidth*2];
            int[,] colorG = new int[bmpHeight*2 , bmpWidth*2];
            int[,] colorB = new int[bmpHeight*2 , bmpWidth*2];
            for (int y = 0; y < bmpHeight; y++)
            {
                for (int x = 0; x < bmpWidth; x++)
                {
                    Color pixelColor = bmpFirst.GetPixel(x, y);
                    int dx = x * 2;
                    int dy = y * 2;
                    colorR[dx, dy] = pixelColor.R;
                    colorR[dx + 1, dy] = pixelColor.R;
                    colorR[dx, dy + 1] = pixelColor.R;
                    colorR[dx + 1, dy + 1] = pixelColor.R;
                    colorG[dx, dy] = pixelColor.G;
                    colorG[dx + 1, dy] = pixelColor.G;
                    colorG[dx, dy + 1] = pixelColor.G;
                    colorG[dx + 1, dy + 1] = pixelColor.G;
                    colorB[dx, dy] = pixelColor.B;
                    colorB[dx + 1, dy] = pixelColor.B;
                    colorB[dx, dy + 1] = pixelColor.B;
                    colorB[dx + 1, dy + 1] = pixelColor.B;
                }
            }
            for (int y = 0; y < (bmpHeight*2); y++)
            {
                for (int x = 0; x < (bmpWidth*2); x++)
                {
                    Color mySpecialColor = Color.FromArgb(colorR[x, y], colorG[x, y], colorB[x, y]);
                    SolidBrush pixelBrush = new SolidBrush(mySpecialColor);
                    g.FillRectangle(pixelBrush, x, y, 1, 1);
                }
            }
