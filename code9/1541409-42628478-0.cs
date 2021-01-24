                float x = pictureBox1.Location.X + e.X;
                float y = pictureBox1.Location.Y + e.Y;
    
                System.Drawing.Graphics graphics = this.CreateGraphics();
    
                PointF center = new PointF(x, y);//this.ClientSize.Width / 2F, this.ClientSize.Height / 2F);
                float radius = 100;
    
                PointF rectOrigin = new PointF(center.X - radius, center.Y - radius);
                RectangleF r = new RectangleF(rectOrigin, new SizeF(radius * 2F, radius * 2F));
    
                using (Pen p = new Pen(Color.Blue, 4))
                {
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    graphics.DrawEllipse(p, r);
                }
