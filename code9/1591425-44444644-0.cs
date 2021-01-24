    using (Pen p = new Pen(Color.Black, penSize)) {
      p.StartCap = LineCap.Round;
      p.EndCap = LineCap.Round;
      if (shouldPaint) {
        g.DrawLine(p, prePoint, new Point(e.X, e.Y));
      }
    }
