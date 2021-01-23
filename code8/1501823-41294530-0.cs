        p[0].X = x;
        p[0].Y = y;
        p[1].X = (float)( x + distance * Math.Cos(angle));
        p[1].Y = (float)( y + distance * Math.Sin(angle));
        p[2].X = (float)( x + distance * Math.Cos(angle + Math.PI / 3));
        p[2].Y = (float)( y + distance * Math.Sin(angle + Math.PI / 3));  
