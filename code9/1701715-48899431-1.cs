    List<List<Point>> Lines = new List<List<Point>>();
    bool drawing = false;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        Lines.Add(new List<Point>());
        Lines.Last().Add(e.Location);
        drawing = true;
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (drawing) { Lines.Last().Add(e.Location); pictureBox1.Invalidate(); }
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        if (drawing)
        {
            this.drawing = false;
            Lines.Last().Add(e.Location);
            pictureBox1.Invalidate();
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        using (var pen = new Pen(Color.FromArgb(150, Color.Yellow), 30)
        {
            LineJoin = System.Drawing.Drawing2D.LineJoin.Round,
            StartCap = System.Drawing.Drawing2D.LineCap.Round,
            EndCap = System.Drawing.Drawing2D.LineCap.Round,
        })
            foreach (var item in Lines)
                e.Graphics.DrawCurve(pen, item.ToArray());
    }
