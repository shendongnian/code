    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        if (points.Count < 2) return;  // no lines to draw, yet
        ScaleGraphics(e.Graphics, points);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using ( Pen pen = new Pen(Color.Blue )
              { Width = 1.5f , LineJoin = LineJoin.Round, MiterLimit = 1f} )
            e.Graphics.DrawLines(pen, points.ToArray());
    }
