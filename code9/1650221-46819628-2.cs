    private Rectangle JoinRects(Rectangle r1, Rectangle r2)
    {
        return new Rectangle(Math.Min(r1.X, r2.X), 
                        Math.Min(r1.Y, r2.Y), 
                        Math.Max(r1.Y + r1.Width, r2.Y + r2.Width), 
                        Math.Max(r1.X + r1.Height, r2.X + r2.Height));
    }
    private bool ShouldJoinRects(Rectangle r1, Rectangle r2)
    {
        if ((r1.X + r1.Width + 1 == r2.X && r1.Y == r2.Y && r1.Height == r2.Height)
         || (r1.X - 1 == r2.x + r2.Width && r1.Y == r2.Y && r1.Height == r2.Height)
         || (r1.Y + r1.Height + 1 == r2.Y && r1.X == r2.X && r1.Width == r2.Width)
         || (r1.Y - 1 == r2.Y + r2.Height && r1.X == r2.X && r1.Width == r2.Width))
        {
            return true;
        } 
        else 
        {
            return false;
        }
    }
