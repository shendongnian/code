    // start with a Width of 1 
    using( Pen pen = new Pen(Color.Black, 1))
    {
      e.Graphics.DrawLine(pen , new Point(0 , 0) , new Point(100, 100));
      pen.Width = 5;
      e.Graphics.DrawLine(pen, new Point(0, 0), new Point(50, 150));
      pen.Width = 10;
      e.Graphics.DrawLine(pen, new Point(0, 0), new Point(30, 200));
    }  // Dispose is called here
