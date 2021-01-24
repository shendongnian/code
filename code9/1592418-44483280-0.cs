    using( Pen p1 = new Pen(Color.Black, 1))
    {
      e.Graphics.DrawLine(p , new Point(0 , 0) , new Point(100, 100));
    }
    using(Pen p5 = new Pen(Color.Black, 5))
    {
        e.Graphics.DrawLine(p5, new Point(0, 0), new Point(50, 150));
    }
    using(Pen p10 = new Pen(Color.Black, 10))
    {
        e.Graphics.DrawLine(p10, new Point(0, 0), new Point(30, 200));
    }
