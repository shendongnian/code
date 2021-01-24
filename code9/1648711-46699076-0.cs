    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.White);
        Pen p = new Pen(Color.Black, 1);
        g.DrawRectangle(p, 0, 0, 50, 50);
        base.OnPaint(e);
    }
