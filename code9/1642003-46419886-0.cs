     CellColor RandomColor()
     {
      do
      {
         r = (byte)R.Next(0, 255);
         b = (byte)R.Next(0, 255);
         g = (byte)R.Next(0, 255);
         a = (byte)R.Next(128, 255);
      }
      while (r + b + g < 200);
      CellColor.B = b;
      CellColor.G = g;
      CellColor.R = r;
      CellColor.A = a;
      return CellColor;
     }
     var row = e.Row;
     row.Background = new SolidColorBrush(RandomColor());
