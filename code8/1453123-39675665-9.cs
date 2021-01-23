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
                Rectangle rDest = new Rectangle(c * w, r * h, w, h);
                Rectangle rSrc = new Rectangle(0, 0, rnd.Next(200) + 10, rnd.Next(200) + 10);
                Rectangle rResult = FitToBox(rSrc, rDest, checkBox1.Checked);
                Rectangle rDestPlaced = new Rectangle(c * w + (int)rResult.X, 
                                            r * h + rResult.Y, rResult.Width, rResult.Height);
                using (Pen pen2 = new Pen(Color.SlateGray, 4f))
                    G.DrawRectangle(pen2, Rectangle.Round(rDest));
                G.DrawRectangle(Pens.Red, rDestPlaced);
                G.FillEllipse(Brushes.LightPink, rDestPlaced);
            }
    }
