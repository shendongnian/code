    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.PageUnit = GraphicsUnit.Millimeter;
        e.Graphics.DrawEllipse(new Pen(Color.Black), 100, 100, 25, 30);
    }
