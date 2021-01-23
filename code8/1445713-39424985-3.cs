    private void drawPanel1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Left))
        {
            Size sz = drawPanel1.BackgroundImage.Size;
            Rectangle rectSrc = new Rectangle(e.X - w2, e.Y - h2, w, h);
            Rectangle rectTgt = new Rectangle(e.X - w, e.Y - h, 2 * w, 2 * h);
            using (Graphics g = drawPanel1.CreateGraphics())  // start optional
            {
                g.TranslateTransform(e.X, e.Y);
                g.RotateTransform(trb_a.Value);
                g.TranslateTransform(-e.X, -e.Y);
                drawPanel1.Refresh();
                g.DrawRectangle(Pens.White, rectSrc);
            }
            using (Graphics g = drawPanel2.CreateGraphics())
            {                                                      // end optional
                using (Bitmap bmp = new Bitmap(sz.Width, sz.Height))
                using (Graphics g2 = Graphics.FromImage(bmp))
                {
                    g2.TranslateTransform(e.X, e.Y);
                    g2.RotateTransform(-trb_a.Value);
                    g2.TranslateTransform(-e.X, -e.Y);
                    g2.DrawImage(drawPanel1.BackgroundImage, rectTgt, rectTgt, 
                                 GraphicsUnit.Pixel);
                    drawPanel2.Refresh();
                    g.DrawImage(bmp, rectSrc, rectSrc, GraphicsUnit.Pixel);
                    Text = testForYellowBitmap(bmp) ? "!!YELLOW!!" : "";
                }
            }
        }
