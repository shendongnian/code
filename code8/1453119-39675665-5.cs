    Random rnd = new Random();
    int cols = rnd.Next(3) + 2;
    int rows = rnd.Next(4) + 3;
    int w = pan_dest.Width / cols;
    int h = pan_dest.Height / rows;
    using (Graphics G = pan_dest.CreateGraphics())
    {
        G.Clear(Color.White);
        for (int c = 0; c < cols; c++)
            for (int r = 0; r < rows; r++)
            {
                RectangleF rDest = new RectangleF(c * w, r * h, w, h);
                RectangleF rSrc = new RectangleF(0, 0, rnd.Next(200) + 10, rnd.Next(200) + 10);
                RectangleF rResult = FitToBox(rSrc, rDest, checkBox1.Checked);
                Rectangle rDestPlaced = new Rectangle(c * w + (int)rResult.X, 
                          r * h + (int)rResult.Y, (int)rResult.Width, (int)rResult.Height);
                using (Pen pen2 = new Pen(Color.SlateGray, 4f))
                    G.DrawRectangle(pen2, Rectangle.Round(rDest));
                G.DrawRectangle(Pens.Red, rDestPlaced );
                G.FillEllipse(Brushes.LightPink, rDestPlaced );
            }
    }
