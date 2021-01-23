    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        int x1 = Math.Max(r1.X, r2.X);
        int x2 = Math.Min(r1.X + r1.Width, r2.X + r2.Width); 
        int y1 = Math.Max(r1.Y, r2.Y);
        int y2 = Math.Min(r1.Y + r1.Height, r2.Y + r2.Height); 
  
        return (x2 >= x1 && y2 >= y1);
    }
