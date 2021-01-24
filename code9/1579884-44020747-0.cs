    private int GetNewX(Rectangle r1, Rectangle r2)
    {
       if (r2.X < r1.X)
       {
           return r1.X - r2.Width;
       }
       else
       {
           return r1.X + r1.Width;
       }
    }
    private int GetNewY(Rectangle r1, Rectangle r2)
    {
       if (r2.Y < r1.Y)
       {
           return r1.Y - r2.Height;
       }
       else
       {
           return r1.Y + r1.Height;
       }
    }
    Pen pen = new Pen(Color.Black);
    Rectangle r1 = new Rectangle(60, 10, 200, 200);
    Rectangle r2 = new Rectangle(40, 25, 200, 160);
    //If overlapped change X,Y of the r2 rectangle
    Rectangle overlapRect = Rectangle.Intersect(r1, r2);
    if (overlapRect.Width > 0 || overlapRect.Height > 0)
    {
        bool betweenX = overlapRect.X >= r1.X && overlapRect.X <= (r1.X + r1.Height);
        bool betweenY = overlapRect.Y >= r1.Y && overlapRect.Y <= (r1.Y + r1.Width);
        if (betweenX)
        {
            r2.X = GetNewX(r1,r2);                    
        }
        else if (betweenY)
        {
            r2.Y = GetNewY(r1, r2);
        }
        else
        {
            if (overlapRect.Width <= overlapRect.Height)
            {
                r2.X = GetNewX(r1, r2);
            }
            else
            {
                r2.Y = GetNewY(r1, r2);
            }
        }                
    }
    Graphics g = this.CreateGraphics();
    g.DrawRectangle(pen, r1);
    g.DrawRectangle(pen, r2);
