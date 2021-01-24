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
