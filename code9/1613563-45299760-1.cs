    static void Fill4(Bitmap bmp, Point pt, Color c0, Color c1)
    {
        Rectangle bmpRect = new Rectangle(Point.Empty, bmp.Size);
        Stack<Point> stack = new Stack<Point>();
        int x0 = pt.X;
        int y0 = pt.Y;
        stack.Push(new Point(x0, y0) );
        while (stack.Any() )
        {
            Point p = stack.Pop();
            if (!bmpRect.Contains(p)) continue;
            Color cx = bmp.GetPixel(p.X, p.Y);
            //if (cx == Color.Black) return;  // optional, to prevent filling the grid
            if (cx == c0)
            {
                bmp.SetPixel(p.X, p.Y, c1);
                stack.Push(new Point(p.X, p.Y + 1));
                stack.Push(new Point(p.X, p.Y - 1));
                stack.Push(new Point(p.X + 1, p.Y));
                stack.Push(new Point(p.X - 1, p.Y));
            }
        }
    }
