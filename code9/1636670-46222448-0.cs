    private void canvas_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Left))
        {
            currentStroke.Add(e.Location);
        }
    }
    private void canvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Left))
        {
            currentStroke.Add(e.Location);
            canvas.Invalidate();
        }
    }
    private void canvas_MouseUp(object sender, MouseEventArgs e)
    {
        if (currentStroke.Count > 1)
        {
            strokes.Add(currentStroke.ToList());
            currentStroke.Clear();
        }
    }
    private void canvas_Paint(object sender, PaintEventArgs e)
    {
        if (strokes.Count > 0 || currentStroke.Count > 0)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.FillMode = FillMode.Winding;
            if (currentStroke.Count > 0)
            {
                gp.AddCurve(currentStroke.ToArray());
                gp.CloseFigure();
            }
            foreach (var stroke in strokes)
            {
                gp.AddCurve(stroke.ToArray());
                gp.CloseFigure();
            }
            using (SolidBrush b = new SolidBrush(Color.FromArgb(77, 177, 99, 22)))
            {
                e.Graphics.FillPath(b, gp);
            }
        }
    }
