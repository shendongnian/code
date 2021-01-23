        private void button4_Click(object sender, EventArgs e       )
        {
            tabControl1.SelectedTab = tabPage1;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "*.bmp|*.bmp|*.jpg|*.jpg|*.*|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                }
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please choose a image file.");
            }
            else
            {
                int bmpHeight = pictureBox1.Image.Height;
                int bmpWidth = pictureBox1.Image.Width;
                if (bmpHeight > 100 || bmpWidth > 100)
                {
                    MessageBox.Show("Image size can't be bigger than 100x100 pixels");
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button10.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button10.Enabled = false;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            tabControl1.SelectedTab = tabPage2;
            int bmpHeight = pictureBox1.Image.Height;
            int bmpWidth = pictureBox1.Image.Width;
            
            Bitmap bmpFirst = (Bitmap)pictureBox1.Image.Clone();
            Graphics g = panel1.CreateGraphics();
            
            int[,] colorR = new int[bmpWidth * 2 , bmpHeight *2];
            int[,] colorG = new int[bmpWidth * 2 , bmpHeight *2];
            int[,] colorB = new int[bmpWidth * 2 , bmpHeight *2];
            
            for (int y = 0; y < bmpHeight; y++)
            {
                for (int x = 0; x < bmpWidth; x++)
                {
                    Color pixelColor = bmpFirst.GetPixel(x, y);
                    int dx = x * 2;
                    int dy = y * 2;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            colorR[dx + i, dy + j] = pixelColor.R;
                            colorG[dx + i, dy + j] = pixelColor.G;
                            colorB[dx + i, dy + j] = pixelColor.B;
                        }
                    }
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
        }
        private void button5_Click(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            tabControl1.SelectedTab = tabPage3;
            int bmpHeight = pictureBox1.Image.Height;
            int bmpWidth = pictureBox1.Image.Width;
            Bitmap bmpFirst = (Bitmap)pictureBox1.Image.Clone();
            Graphics g = panel2.CreateGraphics();
            
            int[,] colorR = new int[bmpWidth * 4, bmpHeight * 4];
            int[,] colorG = new int[bmpWidth * 4, bmpHeight * 4];
            int[,] colorB = new int[bmpWidth * 4, bmpHeight * 4];
            for (int y = 0; y < bmpHeight; y++)
            {
                for (int x = 0; x < bmpWidth; x++)
                {
                    Color pixelColor = bmpFirst.GetPixel(x, y);
                    int dx = x * 4;
                    int dy = y * 4;
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            colorR[dx + i, dy + j] = pixelColor.R;
                            colorG[dx + i, dy + j] = pixelColor.G;
                            colorB[dx + i, dy + j] = pixelColor.B;
                        }
                    }
                }
            }
            for (int y = 0; y < (bmpHeight * 4); y++)
            {
                for (int x = 0; x < (bmpWidth * 4); x++)
                {
                    Color mySpecialColor = Color.FromArgb(colorR[x, y], colorG[x, y], colorB[x, y]);
                    SolidBrush pixelBrush = new SolidBrush(mySpecialColor);
                    g.FillRectangle(pixelBrush, x, y, 1, 1);
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            
            
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            tabControl1.SelectedTab = tabPage4;
            int bmpHeight = pictureBox1.Image.Height;
            int bmpWidth = pictureBox1.Image.Width;
            Bitmap bmpFirst = (Bitmap)pictureBox1.Image.Clone();
            Graphics g = panel3.CreateGraphics();
            int[,] colorR = new int[bmpWidth * 8, bmpHeight * 8];
            int[,] colorG = new int[bmpWidth * 8, bmpHeight * 8];
            int[,] colorB = new int[bmpWidth * 8, bmpHeight * 8];
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
                            colorR[dx + i, dy + j] = pixelColor.R;
                            colorG[dx + i, dy + j] = pixelColor.G;
                            colorB[dx + i, dy + j] = pixelColor.B;
                        }
                    }
                }
            }
            for (int y = 0; y < (bmpHeight * 8); y++)
            {
                for (int x = 0; x < (bmpWidth * 8); x++)
                {
                    Color mySpecialColor = Color.FromArgb(colorR[x, y], colorG[x, y], colorB[x, y]);
                    SolidBrush pixelBrush = new SolidBrush(mySpecialColor);
                    g.FillRectangle(pixelBrush, x, y, 1, 1);
                }
            }
        }
        private void button5_Click_2(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            tabControl1.SelectedTab = tabPage5;
            int bmpHeight = pictureBox1.Image.Height;
            int bmpWidth = pictureBox1.Image.Width;
            Bitmap bmpFirst = (Bitmap)pictureBox1.Image.Clone();
            Graphics g = panel4.CreateGraphics();
            
            int[,] colorR = new int[bmpWidth, bmpHeight];
            int[,] colorG = new int[bmpWidth, bmpHeight];
            int[,] colorB = new int[bmpWidth, bmpHeight];
            for (int y = 0; y < bmpHeight; y++)
            {
                for (int x = 0; x < bmpWidth; x++)
                {
                    Color pixelColor = bmpFirst.GetPixel(x, y);
                    
                    colorR[x, y] = pixelColor.R;
                    colorG[x, y] = pixelColor.G;
                    colorB[x, y] = pixelColor.B;
                    
                }
            }
            int[,] colorSR = new int[bmpWidth /2, bmpHeight /2];
            int[,] colorSG = new int[bmpWidth /2, bmpHeight /2];
            int[,] colorSB = new int[bmpWidth /2, bmpHeight /2];
            for (int i = 0; i < bmpWidth / 2; i++)
            {
                for (int j = 0; j < bmpHeight /2; j++)
                {
                    colorSR[i, j] = (colorR[2 * i, 2 * j] + colorR[2 * i, 2 * j + 1] + colorR[2 * i + 1, 2 * j] + colorR[2 * i + 1, 2 * j + 1]) / 4;
                    colorSG[i, j] = (colorG[2 * i, 2 * j] + colorG[2 * i, 2 * j + 1] + colorG[2 * i + 1, 2 * j] + colorG[2 * i + 1, 2 * j + 1]) / 4;
                    colorSB[i, j] = (colorB[2 * i, 2 * j] + colorB[2 * i, 2 * j + 1] + colorB[2 * i + 1, 2 * j] + colorB[2 * i + 1, 2 * j + 1]) / 4;
                }
            }
            
            for (int y = 0; y < (bmpHeight / 2); y++)
            {
                for (int x = 0; x < (bmpWidth / 2); x++)
                {
                    Color mySpecialColor = Color.FromArgb(colorSR[x, y], colorSG[x, y], colorSB[x, y]);
                    SolidBrush pixelBrush = new SolidBrush(mySpecialColor);
                    g.FillRectangle(pixelBrush, x, y, 1, 1);
                }
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            tabControl1.SelectedTab = tabPage6;
            int bmpHeight = pictureBox1.Image.Height;
            int bmpWidth = pictureBox1.Image.Width;
            Bitmap bmpFirst = (Bitmap)pictureBox1.Image.Clone();
            Graphics g = panel5.CreateGraphics();
            int[,] colorR = new int[bmpWidth, bmpHeight];
            int[,] colorG = new int[bmpWidth, bmpHeight];
            int[,] colorB = new int[bmpWidth, bmpHeight];
            for (int y = 0; y < bmpHeight; y++)
            {
                for (int x = 0; x < bmpWidth; x++)
                {
                    Color pixelColor = bmpFirst.GetPixel(x, y);
                    colorR[x, y] = pixelColor.R;
                    colorG[x, y] = pixelColor.G;
                    colorB[x, y] = pixelColor.B;
                }
            }
            int[,] colorSR = new int[bmpWidth / 4, bmpHeight / 4];
            int[,] colorSG = new int[bmpWidth / 4, bmpHeight / 4];
            int[,] colorSB = new int[bmpWidth / 4, bmpHeight / 4];
            for (int i = 0; i < bmpWidth / 4; i++)
            {
                for (int j = 0; j < bmpHeight / 4; j++)
                {
                    colorSR[i, j] = (colorR[4 * i, 4 * j] + colorR[4 * i, 4 * j + 1] + colorR[4 * i + 1, 4 * j] + colorR[4 * i + 1, 4 * j + 1]) / 4;
                    colorSG[i, j] = (colorG[4 * i, 4 * j] + colorG[4 * i, 4 * j + 1] + colorG[4 * i + 1, 4 * j] + colorG[4 * i + 1, 4 * j + 1]) / 4;
                    colorSB[i, j] = (colorB[4 * i, 4 * j] + colorB[4 * i, 4 * j + 1] + colorB[4 * i + 1, 4 * j] + colorB[4 * i + 1, 4 * j + 1]) / 4;
                }
            }
            for (int y = 0; y < (bmpHeight / 4); y++)
            {
                for (int x = 0; x < (bmpWidth / 4); x++)
                {
                    Color mySpecialColor = Color.FromArgb(colorSR[x, y], colorSG[x, y], colorSB[x, y]);
                    SolidBrush pixelBrush = new SolidBrush(mySpecialColor);
                    g.FillRectangle(pixelBrush, x, y, 1, 1);
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            tabControl1.SelectedTab = tabPage7;
            int bmpHeight = pictureBox1.Image.Height;
            int bmpWidth = pictureBox1.Image.Width;
            Bitmap bmpFirst = (Bitmap)pictureBox1.Image.Clone();
            Graphics g = panel6.CreateGraphics();
            
            int[,] colorR = new int[bmpWidth, bmpHeight];
            int[,] colorG = new int[bmpWidth, bmpHeight];
            int[,] colorB = new int[bmpWidth, bmpHeight];
            for (int y = 0; y < bmpHeight; y++)
            {
                for (int x = 0; x < bmpWidth; x++)
                {
                    Color pixelColor = bmpFirst.GetPixel(x, y);
                    colorR[x, y] = pixelColor.R;
                    colorG[x, y] = pixelColor.G;
                    colorB[x, y] = pixelColor.B;
                }
            }
            int[,] colorSR = new int[bmpWidth / 8, bmpHeight / 8];
            int[,] colorSG = new int[bmpWidth / 8, bmpHeight / 8];
            int[,] colorSB = new int[bmpWidth / 8, bmpHeight / 8];
            for (int i = 0; i < bmpWidth / 8; i++)
            {
                for (int j = 0; j < bmpHeight / 8; j++)
                {
                    colorSR[i, j] = (colorR[8 * i, 8 * j] + colorR[8 * i, 8 * j + 1] + colorR[8 * i + 1, 8 * j] + colorR[8 * i + 1, 8 * j + 1]) / 4;
                    colorSG[i, j] = (colorG[8 * i, 8 * j] + colorG[8 * i, 8 * j + 1] + colorG[8 * i + 1, 8 * j] + colorG[8 * i + 1, 8 * j + 1]) / 4;
                    colorSB[i, j] = (colorB[8 * i, 8 * j] + colorB[8 * i, 8 * j + 1] + colorB[8 * i + 1, 8 * j] + colorB[8 * i + 1, 8 * j + 1]) / 4;
                }
            }
            for (int y = 0; y < (bmpHeight / 8); y++)
            {
                for (int x = 0; x < (bmpWidth / 8); x++)
                {
                    Color mySpecialColor = Color.FromArgb(colorSR[x, y], colorSG[x, y], colorSB[x, y]);
                    SolidBrush pixelBrush = new SolidBrush(mySpecialColor);
                    g.FillRectangle(pixelBrush, x, y, 1, 1);
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "*.bmp|*.bmp|*.jpg|*.jpg|*.*|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                }
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please choose a image file.");
            }
            else
            {
                int bmpHeight = pictureBox1.Image.Height;
                int bmpWidth = pictureBox1.Image.Width;
                if (bmpHeight > 800 || bmpWidth > 800)
                {
                    MessageBox.Show("Image size can't be bigger than 800x800 pixels.");
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button10.Enabled = false;
                }
                else
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button10.Enabled = false;
                }
            }
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            tabControl1.SelectedTab = tabPage8;
            int bmpHeight = pictureBox1.Image.Height;
            int bmpWidth = pictureBox1.Image.Width;
            Bitmap bmpFirst = (Bitmap)pictureBox1.Image.Clone();
            Graphics g = panel7.CreateGraphics();
            int[,] colorR = new int[bmpWidth, bmpHeight];
            int[,] colorG = new int[bmpWidth, bmpHeight];
            int[,] colorB = new int[bmpWidth, bmpHeight];
            for (int y = 0; y < bmpHeight; y++)
            {
                for (int x = 0; x < bmpWidth; x++)
                {
                    Color pixelColor = bmpFirst.GetPixel(x, y);
                    
                    colorR[x, y] = pixelColor.R;
                    colorG[x, y] = pixelColor.G;
                    colorB[x, y] = pixelColor.B;
                    
                }
            }
            for (int y = 0; y < bmpHeight; y++)
            {
                for (int x = 0; x < bmpWidth; x++)
                {
                    int dx = bmpWidth - 1;
                    int dy = bmpHeight - 1;
                    Color mySpecialColor = Color.FromArgb(colorR[dx - x, dy - y], colorG[dx - x, dy - y], colorB[dx - x, dy - y]);
                    SolidBrush pixelBrush = new SolidBrush(mySpecialColor);
                    g.FillRectangle(pixelBrush, x, y, 1, 1);
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "*.bmp|*.bmp|*.jpg|*.jpg|*.*|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                }
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please choose a image file.");
            }
            else
            {
                int bmpHeight = pictureBox1.Image.Height;
                int bmpWidth = pictureBox1.Image.Width;
                if (bmpHeight > 800 || bmpWidth > 800)
                {
                    MessageBox.Show("Image size can't be bigger than 800x800 pixels");
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button10.Enabled = false;
                }
                else
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button10.Enabled = true;
                }
            }
        }
    }
