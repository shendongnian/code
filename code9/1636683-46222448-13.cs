    private void PaintToBitmap(Bitmap bmp)
    {
        Color overlayColor = Color.FromArgb(77, 22, 99, 99);
        using (Graphics g = Graphics.FromImage(bmp))
        using (Pen p = new Pen(overlayColor, 15f))
        {
            p.MiterLimit = p.Width / 2;
            p.EndCap = LineCap.Round;
            p.StartCap = LineCap.Round;
            p.LineJoin = LineJoin.Round;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (currentStroke.Count > 0)
            {
                g.DrawCurve(p, currentStroke.ToArray());
            }
            foreach (var stroke in strokes)
                g.DrawCurve(p, stroke.ToArray());
        }
        SetAlphaOverlay(bmp, overlayColor);
    }
