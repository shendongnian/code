            private void MyRectangle(Graphics g, int p1, int p2)
            {           
                g.DrawRectangle(new Pen(Brushes.Black), p1, p2, 30, 30);           
            }
    
            void GraphicFor(PictureBox pictureBox, Action<Graphic> draw)
            {
                Bitmap myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
    
                using (Graphics g = Graphics.FromImage(myBitmap))
                {
                    draw(g);
                }
                pictureBox.Image = myBitmap;
            }
            private void Form2_Load(object sender, EventArgs e)
            {
                GraphicFor(this.pictureBox1, g =>
                {
                    MyRectangle(g, 120, 120);
                    MyRectangle(g, 180, 120);
                });
                
            }
