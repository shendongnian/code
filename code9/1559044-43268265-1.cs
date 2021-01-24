    Bitmap bmp = new Bitmap(400, 400);
    GraphicsPath gp = new GraphicsPath();
    using (Graphics g = Graphics.FromImage(bmp))
    using (Font f = new Font("Tahoma", 40f))
    {
        g.ScaleTransform(4,4);
        gp.AddString("Y?", f.FontFamily, 0, 40f, new Point(0, 0), StringFormat.GenericDefault);
        g.DrawPath(Pens.Gray, gp);
        gp.Flatten(new Matrix(), 0.2f);  // <<== *
        g.DrawPath(Pens.DarkSlateBlue, gp);
        for (int i = 0; i < gp.PathPoints.Length; i++)
        {
            PointF p = gp.PathPoints[i];
            g.FillEllipse(Brushes.DarkOrange, p.X-1, p.Y - 1, 2, 2);
        }
        pictureBox1.Image = bmp;
    }
