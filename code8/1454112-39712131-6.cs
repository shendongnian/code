    g.FillPath(Brushes.MediumSeaGreen, path);
    int ew = 8; // edge width
    for (int i = 0; i < ew ; i++)
        using (Pen pen = new Pen(Color.FromArgb(255 - i * 255 / ew, Color.DarkSlateBlue), i ))
        {
            pen.Alignment = PenAlignment.Inset;
            g.DrawPath(pen, path);
        }
