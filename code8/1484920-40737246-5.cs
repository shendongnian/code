        private void drawRect(Graphics g, int sx, int sy, int ex, int ey, int w, int h)
        {
            using (Brush cloud_brush = new SolidBrush(Color.FromArgb(80, Color.Black)))
            {
                //Top ok
                g.FillRectangle(cloud_brush, 0, 0, w, sy);
                //Bottom
                g.FillRectangle(cloud_brush, 0, ey, w, h);
                //Left ok
                g.FillRectangle(cloud_brush, 0, sy, sx, ey - sy);
                //Right
                g.FillRectangle(cloud_brush, ex, sy, w, ey - sy);
            }
        }
    
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            drawRect(e.Graphics,80, 190, 160, 140, 100, 130);
        }
