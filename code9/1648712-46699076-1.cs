    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using (Graphics g = e.Graphics)
        {
            g.Clear(Color.White);
            using (Pen p = new Pen(Color.Black, 1))
            {
                g.DrawRectangle(p, 0, 0, 50, 50);
            }
        }
    }
