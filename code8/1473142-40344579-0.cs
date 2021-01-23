    for (int x = 0; x < shadow.Width; x++)
    {
        var color = shadow.GetPixel(x, y);
        color = Color.FromArgb((int)((double)color.A * 0.2), 0, 0, 0);
        shadow.SetPixel(x, y, color);
    }
    }
    var finalComposite = new Bitmap(finalImage.Width, finalImage.Height, PixelFormat.Format32bppArgb);
    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalComposite))
    {
    g.Transform = new Matrix(new Rectangle(0, 0, shadow.Width, shadow.Height), new Point[]{
        new Point(50,20),
        new Point(width+50, 20),
        new Point(0, height)
    });
    g.DrawImageUnscaled(shadow, new Point(0, 0));
    g.ResetTransform();
    g.DrawImageUnscaled(finalImage, new Point(0, 0));
    }
