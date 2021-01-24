    private override void OnPaint(object sender, PaintEventArgs e)
    {
      Pen blackPen = new Pen(Color.Black, 3);
      Point point1 = new Point(PB[0].Location.X, PB[0].Location.Y);
      Point point2 = new Point(PB[1].Location.X, PB[1].Location.Y);
      e.Graphics.DrawLine(blackPen, point1, point2);
    }
