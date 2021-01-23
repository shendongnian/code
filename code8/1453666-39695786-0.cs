    using (var b = new Bitmap(DisplayPanel.Width, DisplayPanel.Height))
    using (var g = Graphics.FromImage(b))
    {
        g.FillRectangle(Brushes.White, 0, 0, DisplayPanel.Width, DisplayPanel.Height);
        g.FillRectangle(Brushes.Black, 0, 0, DisplayPanel.Width, DisplayPanel.Height);
        x.DrawImageUnscaled(b, 0, 0);
    }
