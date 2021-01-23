    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        return(r2.X < r1.X + r1.Width) &&
            (r1.X < (r2.X + r2.Width)) && 
            (r2.Y < r1.Y + r1.Height) &&
            (r1.Y < r2.Y + r2.Height); 
    }
 
