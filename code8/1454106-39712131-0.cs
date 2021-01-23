    g.FillPath(Brushes.MediumSeaGreen, path);
    for (int i = 0; i < 8; i++)
        using (Pen pen = new Pen(Color.FromArgb(255 - i * 255 / 8, Color.DarkSlateBlue), i ))
        {
            pen.Alignment = PenAlignment.Inset;
            g.DrawPath(pen, path);
        }
