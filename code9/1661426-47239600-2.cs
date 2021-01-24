    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      using(var blackPen = new Pen(Color.Black, 3))
        e.Graphics.DrawLine(blackPen, PB[0].Location, PB[1].Location);
    }
